# AWS
- [AWS](#aws)
	- [EC2, Elastic Compute Cloud](#ec2-elastic-compute-cloud)
		- [Pay options](#pay-options)
		- [Security Group](#security-group)
		- [Key par](#key-par)
		- [Autoscaling groups](#autoscaling-groups)
			- [Termination protection](#termination-protection)
				- [Protect instance from scale in](#protect-instance-from-scale-in)
				- [Suspend autoscaling processes](#suspend-autoscaling-processes)
		- [How to's](#how-tos)
			- [Connect to a EC2 by terminal (Linux/Mac)](#connect-to-a-ec2-by-terminal-linuxmac)
			- [Convert the instance into a Web server](#convert-the-instance-into-a-web-server)
	- [EBS, Elastic Block Storage](#ebs-elastic-block-storage)
		- [What it is](#what-it-is)
		- [Characteristics](#characteristics)
	- [IAM, Identity Access Management](#iam-identity-access-management)
		- [Critical terms](#critical-terms)
		- [Characteristics](#characteristics-1)
	- [ELB, Elastic Load Balancer](#elb-elastic-load-balancer)
		- [Types](#types)
		- [Errors](#errors)
		- [Critical terms](#critical-terms-1)
			- [X-Forwareded-For Header](#x-forwareded-for-header)

## EC2, Elastic Compute Cloud

___

### Pay options

- **On demand**: Paid at a fixed rate by the hour/second
- **Reserved**: Provides a capacity reservation, and offer a significcant discount on the hourly charge for an instance
- **Spot**: Enables you tou **bid** whatever price you want for instance capacity.
- **Dedicated Hosts**: Physical EC2 server dedicated for you use.

### Security Group

Is a set of firewall rules that control the traffic of your instance

### Key par

Consist of a public key that AWS stores, and a private key that you store. Togheter allow you to connect to your instance securely. You can share the public key, but `NEVER SHARE THE PRIVATE ONE`

### Autoscaling groups

#### Termination protection

##### Protect instance from scale in

Check the `Enable instance scale-in protection`. To understand how this mechanism works, check this page: https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-instance-termination.html

##### Suspend autoscaling processes

These are the processes you can choose to suspend:

- `Terminate`
- `Launch`
- `AddToLoadBalancer`
- `AlarmNotification`
- `AZRebalance`
- `HealthCheck`
- `ReplaceUnhealthy`
- `ScheduledActions`

### How to's

#### Connect to a EC2 by terminal (Linux/Mac)


- Add your compure as a known host and connect to the instance
  - Go where you have the private key
  - Change the permissions on the file
        >`chmod 400 MyNewKeyPair.pm`
  - Connect to the instance
    >`ssh ec2-user@35.153.184.58 -i MyNewKeyPar.pem`
- Elevate permissions to root
    > `sudo su`

#### Convert the instance into a Web server 


```bash
yum update -y
yum install httpd -y # Install Apache
service httpd start  # Start service
checkconfig httpd on # Set apache to start on system start
service httpd status # Check if server is running

```

## EBS, Elastic Block Storage

___

### What it is

Allows you to create storage volumes and attach them to Amazon EC2 instances.

### Characteristics

- Amazon EBS volumes are Availability zone specific

## IAM, Identity Access Management

___

### Critical terms

- Users - End Users (people), A user can:
  - Be member of a group
  - Have policies attached directly
- Groups - A *collection of users* under one **set of permissions**. A way to group our users and apply policies to them collectively
- Roles - You create roles and can then ***assign*** them to AWS resources, **Is a set of policies**. You can assign roles to:
  - Applications running on EC2 instances
  - An AWS service that needs to act on resources in your account to provide its features
  - Users from a corporate directory who use identity federation with SAML
- Policies - A document that defines one (or more) permissions. When attached to an entity, the latter will have the permissions defined in the policy. Can be **Attached** to:
  - A user
  - A group
  - A role

### Characteristics

- IAM Is `global` (across all regions)
- The `root account` is the account created when first setup your AWS account. It has complete Admin access
- New users have **No permissions**

## ELB, Elastic Load Balancer

___

### Types

- **Application Load balancer**: Works on the 7th layer of the OSI model (Application layer)
  - You can create advanced request routing, sending specified request to specific web servers.
- **Network Load Balancer**: Works on the 4th layer of the OSI Model (Transport layer). Used for performance.
  - Are best suited for load balancing of TCP traffic where extreme performance is required.
- **Classic Load Balancer**: Kind of legacy load balancer type.
  - You can load balance HTTP/HTTPS and user Layer 7 specific features, such as X-Forwarded and sticky sessions.
  - You can also use strict Layer 4 load balancing for applications that rely purely on the TCP protocol.

### Errors

- If the application stops responding, the ***Classic*** Load balancer responds with a `504` error. The 504 means the gateway has timed out.

### Critical terms

#### X-Forwareded-For Header

This header has the **public ip** (IPv4) of the user that made the request to the Load balancer.

User (124.12.3.231) ---> Load Balancer (10.0.023) ---> Application (Recieves 10.0.0.23, but can look up for the public ip from the `X-Forwarded-For`)