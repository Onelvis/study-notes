# Infrastructure as code

- [Infrastructure as code](#infrastructure-as-code)
	- [Terraform](#terraform)
		- [Commands](#commands)
		- [Terraform loads variables in the following order, with later sources taking precedence over earlier ones:](#terraform-loads-variables-in-the-following-order-with-later-sources-taking-precedence-over-earlier-ones)
		- [How To's](#how-tos)

## Terraform

___

- The `profile` attribute int your provider block refers Terraform to the AWS credential stored in your AWS Config File.

- The `resource` block refers to a infraestructure piece such as a EC2 instance or a Heroku application

### Commands

`terraform init` -> Downloads and install providers used in the configuration, which in this case is the aws provider 

`terraform fmt` --> Automatically updates configurations in the current directory for easy readability and consistency.

`terraform validate` --> Checks and reports errors within modules, attribute names, and value types

`terraform console` --> Open terraform console (Remeber to run `terraform init` before this) 

`terraform plan` --> Get a terraform plan

`terraform apply` --> Run a terraform plan

This is a shortcut for:
`terraform plan -out file; terraform apply file; rm file`

Recommended approach:
>`terraform plan -out file`  
>`terraform apply file`

### Terraform loads variables in the following order, with later sources taking precedence over earlier ones:

1. Environment variables
2. The terraform.tfvars file, if present.
3. The terraform.tfvars.json file, if present.
4. Any *.auto.tfvars or *.auto.tfvars.json files, processed in lexical order of their filenames.
5. Any -var and -var-file options on the command line, in the order they are provided. (This includes variables set by a Terraform Cloud workspace.)

### How To's

`terraform state list` --> Show list of resources in the state

`terraform refresh` --> Update the state file

`terraform appply -var="region=us-east-1"` -->Using command line flags to provide variables:

`terraform apply -var-file="sensitive.tfvars"` --> Set the `.tfvars` that will be used