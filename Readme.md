# Setup
docker-compose build
docker-compose up

# Delete existing nodes
MATCH (n) DETACH DELETE n

# Create new nodes
CREATE (ee:Product {name: "HP",org:"OptumCare"})
CREATE (ee:Product {name: "CMR",org:"OptumCare"})

CREATE (ee:Analytics {name: "Medical Referral", notes:""})

CREATE (ee:Analytics {name: "Practitioner", notes:""})
![alt text](https://github.com/nafisdev/zudio/blob/main/api_poc.jpg?raw=true)
![alt text](https://github.com/nafisdev/zudio/blob/main/graph_poc.jpg?raw=true)
