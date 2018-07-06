from flask import Flask, render_template

app = Flask(__name__)

@app.route('/play')

def playground():
    return render_template('playground.html')

@app.route('/play/<int:value>')
def playgroundGames(value):
    print(value)
    return render_template('playground2.html', x=value)

@app.route('/play/<int:value>/<color>')
def playgroundGamesColors(value, color):
    print(value)
    print(color)
    return render_template('playground3.html', x=value, color=color)

if __name__=="__main__":
    app.run(debug=True)