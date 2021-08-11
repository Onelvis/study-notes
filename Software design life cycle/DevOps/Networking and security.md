# Networking and security

## Load balancers

### Layer 4 Load balancer

- Doesn't know about the data, only cares about the Ip and the port that the data should go.
- It bases the decision on the source and destination IP addresses and ports.

#### Network Address Translation (NAT)

A layer 4 load uses NAT to change the destination IP address to the one that the server that it choosed has. Similarly, when forwarding the destination server response to the client, it changes the destination server IP for it's own.

Client request: `[CLIENT_IP][DATA][LOAD_BALANCER_IP]`
Load balancer: `[LOAD_BALANCER_IP][DATA][DESTINATION_SERVER_IP]`
Destination server recieves response: `[]
