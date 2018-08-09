function rFloodFill(canvas, start, newcolor, startcolor=canvas[start]){
    if(start){
        canvas[start] = newcolor;
        if (canvas[start[0]+1,start[1]]==startcolor){
            start[0] += 1;
            return rFloodFill(canvas, start, newcolor, startcolor)
        }
        if (canvas[start[0]-1,start[1]]==startcolor){
            start[0] -= 1;
            return rFloodFill(canvas, start, newcolor, startcolor)
        }
        if (canvas[start[0],start[1]+1]==startcolor){
            start[1] += 1;
            return rFloodFill(canvas, start, newcolor, startcolor)
        }
        if (canvas[start[0],start[1]-1]==startcolor){
            start[1] -= 1;
            return rFloodFill(canvas, start, newcolor, startcolor)
        }
    }
    return;
}