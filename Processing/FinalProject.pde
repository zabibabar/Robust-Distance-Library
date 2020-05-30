
import java.util.*;

ArrayList<Polygon> polygonList = new ArrayList<Polygon>();
Polygon polygon = new Polygon();


boolean saveImage = false;
float displayDistance = 0;

void setup(){
  size(800,800,P3D);
  frameRate(30);
}


void draw(){
  background(255);
  
  translate( 0, height, 0);
  scale( 1, -1, 1 );
  
  strokeWeight(3);
  
  fill(0);
  stroke(0);

  polygon.draw();

  for(Polygon poly: polygonList){
    poly.draw();
  }
  
  
  displayDistance = distanceFromPolygonList(polygonList);
  
  fill(0);
  stroke(0);
  textSize(18);
  
  textRHC( "Controls:", 10, height-20 );
  textRHC( "Mouse Click: Add a point to current data structure", 10, height-40 );
  textRHC( "Enter: Start a new a data structure", 10, height-60);
  textRHC( "c: Clear Points", 10, height-80 );
  textRHC( "Number of data structures: " + polygonList.size(), 10, height-100);
  fill(200, 50, 0);
  textRHC( "Shortest Distance: " + displayDistance, 10, height-780 );

  
  if( saveImage ) saveFrame( ); 
  saveImage = false;
  
}

void textRHC( int s, float x, float y ){
  textRHC( Integer.toString(s), x, y );
}


void textRHC( String s, float x, float y ){
  pushMatrix();
  translate(x,y);
  scale(1,-1,1);
  text( s, 0, 0 );
  popMatrix();
}

Point sel = null;

void keyPressed(){
  if (key == 'c') {
    int N = polygonList.size();
    for(int i = 0; i < N; i++) polygonList.clear();
    polygon.p.clear(); 
  }
  
  if (key == ENTER && polygon.p.size()>0){
    polygonList.add(polygon);
    polygon = new Polygon();
  }
  
}

void mousePressed(){
  int mouseXRHC = mouseX;
  int mouseYRHC = height-mouseY;
  
  float dT = 6;
  for( Point p : polygon.p ) {
    float d = dist( p.p.x, p.p.y, mouseXRHC, mouseYRHC );
    if( d < dT ){
      dT = d;
      sel = p;
    }
  }
  if( sel == null ){
    sel = new Point(mouseXRHC,mouseYRHC);  
    polygon.addPoint(sel);  
  }
  
  
  
}

void mouseDragged(){
  int mouseXRHC = mouseX;
  int mouseYRHC = height-mouseY;
  if( sel != null ){
    sel.p.x = mouseXRHC;   
    sel.p.y = mouseYRHC;
  }
}

void mouseReleased(){
  sel = null;
}




  
