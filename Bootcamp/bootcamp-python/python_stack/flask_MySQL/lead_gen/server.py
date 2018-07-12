from flask import Flask, render_template, session, request, redirect, flash
from mysqlconnection import connectToMySQL
app = Flask(__name__)
app.secret_key = "communication"
mysql = connectToMySQL('lead_gen')

@app.route("/")
def index():
    all_clients = mysql.query_db("SELECT * FROM clients")
    clients_w_leads = mysql.query_db("SELECT COUNT(clients_id) as count, b.id, b.first_name, b.last_name, b.email FROM leads a LEFT JOIN clients b ON b.id = a.clients_id GROUP BY clients_id;")
    print(all_clients)
    all_leads = mysql.query_db("SELECT * FROM leads")
    query = "SELECT * FROM clients WHERE created_at < %(to_date)s AND created_at > %(from_date)s;"
    data = {
        "to_date": session['to_date'],
        "from_date": session['from_date']
    }
    client_range = mysql.query_db(query, data)
    query = "SELECT * FROM leads WHERE created_at < %(to_date)s AND created_at > %(from_date)s;"
    data = {
        "to_date": session['to_date'],
        "from_date": session['from_date']
    }
    lead_range = mysql.query_db(query, data)

    return render_template("index.html", clients = all_clients, leads = all_leads, clients_count=clients_w_leads, client_range=client_range, lead_range=lead_range)

@app.route('/date_range', methods=['POST'])
def date_range():
    print(request.form['from_date'], request.form['to_date'])
    session['from_date'] = request.form['from_date']
    session['to_date'] = request.form['to_date']
    return redirect('/')

@app.route('/add_client', methods=['POST'])
def add_client():
    query = "INSERT INTO clients (first_name, last_name, email, created_at, updated_at) VALUES (%(first_name)s, %(last_name)s, %(email)s, NOW(), NOW());"
    
    data = {
             'first_name': request.form['first_name'],
             'last_name':  request.form['last_name'],
             'email': request.form['email'],
           }
    mysql.query_db(query, data)
    return redirect('/')

@app.route('/add_lead', methods=['POST'])
def add_lead():
    print(request.form)
    query = "INSERT INTO leads (first_name, last_name, email, found_at, created_at, updated_at, clients_id) VALUES (%(first_name)s, %(last_name)s, %(email)s, %(found_at)s, NOW(), NOW(), %(clients_id)s);"
    
    data = {
            'first_name': request.form['first_name'],
            'last_name':  request.form['last_name'],
            'email': request.form['email'],
            'found_at': request.form['found_at'],
            'clients_id': request.form['clients_id']
           }
    mysql.query_db(query, data)
    return redirect('/')

if __name__ == "__main__":
    app.run(debug=True)