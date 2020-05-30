

class Point {
  
   public PVector p;

   public Point( float x, float y ){
     p = new PVector(x,y);
   }

   public Point(PVector _p0 ){
     p = _p0;
   }

   public boolean equals(PVector _p0){
     if (p.x == _p0.x && p.y == _p0.y)
       return true;
     return false;
   }
   
   public void draw(){
     ellipse( p.x,p.y, 10,10);
     pushMatrix();
     translate(p.x+10,p.y+10);
     scale(1,-1,1);
     text( p.toString(), 0, 0 );
     popMatrix();
   }
   
   float getX(){ return p.x; }
   float getY(){ return p.y; }
   
   float x(){ return p.x; }
   float y(){ return p.y; }
   
   public float distance( Point o ){
     return PVector.dist( p, o.p );
   }
   
   public String toString(){
     return "[" + p.x + ", " + p.y + "]";
   }
   
   
}
