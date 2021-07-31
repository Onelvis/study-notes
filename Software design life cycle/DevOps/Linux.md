# Linux
- [Linux](#linux)
	- [Create ssh enabled user](#create-ssh-enabled-user)
	- [Add ssh key to bitbucket repo](#add-ssh-key-to-bitbucket-repo)
	- [Add ODBC Driver 17 for SQL on Amazon Linux](#add-odbc-driver-17-for-sql-on-amazon-linux)
	- [Commands](#commands)
		- [`>` Standard output redirect:](#-standard-output-redirect)
## Create ssh enabled user

```bash
sudo su
useradd new_user
mkdir /home/new_user/.ssh
echo "key" > /home/new_user/.ssh/authorized_keys # You need to create those directory/files if not exists
chown -R new_user /home/new_user/.ssh # Not sure if this is necesary
sudo systemctl restart sshd.service # For CentOs Linux

```

## Add ssh key to bitbucket repo

1. Generate key `ssh-keygen`
2. Add the key to the ssh agent `ssh-add ./.ssh/id_rsa`
3. `ssh-keyscan bitbucket.org >> known_hosts`
4. Add the public key to the repo

## Add ODBC Driver 17 for SQL on Amazon Linux 

- `yum install msodbcsql17`

## Commands

### `>` Standard output redirect:

The > sign is used for redirecting the output of a program to something other than stdout (standard output, which is the terminal by default).

- The `>>` appends to a file or creates the file if it doesn't exist.
- The `<` symbol is used for input(STDIN) redirection
- `>&`re-directs output of one file to another.
