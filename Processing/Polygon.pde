

class Polygon {
  
   ArrayList<Point> p = new ArrayList<Point>();
     
   Polygon( ){  }
   
   void draw(){
     int N = p.size();
     for(int i = 0; i < N; i++) p.get(i).draw();
     for(int i = 0; i < N; i++ ){
       line( p.get(i).x(), p.get(i).y(), p.get((i+1)%N).x(), p.get((i+1)%N).y() );
     }
   }
   
   void addPoint( Point _p ){ p.add( _p ); }
   
  boolean pointInPolygon( Point p1 ){
     // TODO: Check if the point p is inside of the 
     int intersectionCount= 0;
     int N = p.size();
     Edge pEdge = new Edge(p1, new Point(800, 800));
     for (int i = 0; i < N; i++){
       Edge edge = new Edge(p.get(i), p.get((i+1)%N));
       if (pEdge.intersectionTest(edge)) intersectionCount++;
     }
     println(intersectionCount);
     if (intersectionCount%2 == 1) return true;
     return false;
   }
   
}
