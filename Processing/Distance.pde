float distanceFromPointToPoint(Point p1, Point p2) {
  PVector v1 = new PVector(p1.p.x, p1.p.y);   
  PVector v2 = new PVector(p2.p.x, p2.p.y);   
  
  return PVector.dist(v1, v2);
}

float distanceFromPointToEdge(Point p, Edge e) {
  float edgeDist2 = e.distanceSquared();
  if (edgeDist2 == 0) {
    return distanceFromPointToPoint(p, e.p0);
  }
    
  float t = ((p.p.x - e.p0.p.x) * (e.p1.p.x - e.p0.p.x) + (p.p.y - e.p0.p.y) * (e.p1.p.y - e.p0.p.y)) / edgeDist2; 
  t = max(0, min(1, t));

  float x = e.p0.p.x + t*(e.p1.p.x-e.p0.p.x);
  float y = e.p0.p.y + t*(e.p1.p.y-e.p0.p.y);

  /*Point onTheLine = new Point(x, y);
  Edge edge = new Edge(p, onTheLine);
  edge.drawDotted();*/
  
  float dx = x - p.p.x; 
  float dy = y - p.p.y;
  
  float dist = sqrt(sq(dx)+sq(dy));
  return dist;
}

float distanceFromPointToPolygon(Point p, Polygon poly) {
  if (poly.p.size() == 0) return 0;
  println(poly.pointInPolygon(p));
  if (poly.pointInPolygon(p)) return 0;
  if (poly.p.size() == 1) return distanceFromPointToPoint(p, poly.p.get(0));
  
  float minDist = sqrt(sq(800) + sq(800));
  int N = poly.p.size();

  for(int i = 0; i < N; i++ ){
    Edge e = new Edge(poly.p.get(i), poly.p.get((i+1)%N));
    float dist = distanceFromPointToEdge(p, e);
    if (dist < minDist) minDist = dist;
  }
  
  return minDist;
}

float distanceFromEdgeToEdge(Edge e1, Edge e2) {
  
  if (e1.intersectionTest(e2)) return 0;
  
  float distA = distanceFromPointToEdge(e1.p0, e2);
  float distB = distanceFromPointToEdge(e1.p1, e2);
  float distC = distanceFromPointToEdge(e2.p0, e1);
  float distD = distanceFromPointToEdge(e2.p1, e1);
  
  float [] dists = { distA, distB, distC, distD};
  
  float minDist = min(dists); 
  
  return minDist;
}

float distanceFromEdgeToPolygon(Edge e, Polygon poly) {
  if (poly.p.size() == 0) return 0;
  if (poly.pointInPolygon(e.p0) && poly.pointInPolygon(e.p1)) return 0;
  println(poly.pointInPolygon(e.p0));
  println(poly.pointInPolygon(e.p1));
  if (poly.p.size() == 1) return distanceFromPointToEdge(poly.p.get(0), e);
  
  float minDist = sqrt(sq(800) + sq(800));
  
  int N = poly.p.size();
  for(int i = 0; i < N; i++ ){
    Edge e1 = new Edge(poly.p.get(i), poly.p.get((i+1)%N));
    float dist = distanceFromEdgeToEdge(e1, e);
    if (dist < minDist) minDist = dist;
  }
  
  return minDist;
}

float distanceFromPolygonToPolygon(Polygon p1, Polygon p2) {

  if (p1.p.size() == 0 || p2.p.size() == 0) return 0;
  
  if (p1.p.size() == 1) {
    return distanceFromPointToPolygon(p1.p.get(0), p2);
  }
  
   if (p2.p.size() == 1) {
    return distanceFromPointToPolygon(p2.p.get(0), p1);
  }
  
  float minDist = sqrt(sq(800) + sq(800));
  
  int N1 = p1.p.size();
  
  for(int i = 0; i < N1; i++ ){
    Edge e1 = new Edge(p1.p.get(i), p1.p.get((i+1)%N1));
    float dist = distanceFromEdgeToPolygon(e1, p2);
    if (dist < minDist) minDist = dist;
  }
  
  return minDist;
}

float distanceFromPolygonList(ArrayList<Polygon> polygons) {
  
  if (polygons.size() < 2) return 0;
  
  float minDist = sqrt(sq(800) + sq(800));
  int N = polygons.size();
  
  for(int i = 0; i < N; i++ ){
    for (int j = i+1; j < N; j++){
      float dist = distanceFromPolygonToPolygon(polygons.get(i), polygons.get(j));
      if (dist < minDist) minDist = dist;
    }
  }
  return minDist;
}
