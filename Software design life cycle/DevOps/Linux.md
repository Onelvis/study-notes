# Linux
- [Linux](#linux)
	- [Create ssh enabled user](#create-ssh-enabled-user)
	- [Add ssh key to bitbucket repo](#add-ssh-key-to-bitbucket-repo)
	- [Add ODBC Driver 17 for SQL on Amazon Linux](#add-odbc-driver-17-for-sql-on-amazon-linux)
	- [Hostname](#hostname)
	- [Commands](#commands)
		- [File permissions management](#file-permissions-management)
		- [Filesystem navigation](#filesystem-navigation)
			- [$ `pwd`](#-pwd)
		- [File management](#file-management)
			- [$ `stat` <file/directory name>](#-stat-filedirectory-name)
			- [$ `touch`](#-touch)
			- [$ `last`](#-last)
			- [$ `cat`](#-cat)
			- [$ `rm`](#-rm)
			- [$ `rsync`](#-rsync)
		- [System management](#system-management)
			- [$ `strace <command>`](#-strace-command)
			- [$ `hostnamectl`](#-hostnamectl)
			- [$ `df`](#-df)
		- [Users management](#users-management)
			- [$ `su <user_name>`](#-su-user_name)
			- [$ `w`](#-w)
			- [$ `who`](#-who)
			- [$ `top`](#-top)
		- [Networking](#networking)
			- [$ `netstat`](#-netstat)
			- [$ `ssh`](#-ssh)
	- [Stdout, Stdin and Stderr redirection](#stdout-stdin-and-stderr-redirection)
		- [POSIX File descriptors](#posix-file-descriptors)
		- [Stdout redirection `>`](#stdout-redirection-)
		- [Stdin redirection `<`](#stdin-redirection-)
		- [Stderr redirection `2>`](#stderr-redirection-2)
		- [Redirection vs Pipes](#redirection-vs-pipes)
		- [Pipes `|`](#pipes-)
	- [Services](#services)
	- [File system](#file-system)
		- [Inodes](#inodes)
		- [Linux Service Management](#linux-service-management)
	- [Networking](#networking-1)
		- [Socket vs Port](#socket-vs-port)
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

## Hostname

There are tree types of hostnames in linux:

1. ***"Pretty" hostname***, which allows to have special characters

2. ***Static hostname***, that is the one that gets loaded with the kernel, and cand be found at `/etc/hostname`

3. ***Transient hostnane***, this is the one that will appear in the network.

## Commands

### File permissions management

### Filesystem navigation

#### $ `pwd`

Shows current directory full path

`ls`: List all the directories and files on the current directory

- `-a`: Show hidden files

- `-l`: Format as list

### File management

#### $ `stat` <file/directory name>

This is a syscall that will print the information about an inode.

#### $ `touch`

Create file

#### $ `last`

By default, displays the list of all users logged in and out since the file `/var/log/wtmp` was created.

- `-<number>` specific lines to display (Top to bottom)

- `-R` Hide hostname of the users

#### $ `cat`

"Print" the content of a file

#### $ `rm`

>Delete a file
>
>- `-r`: Delete recursively
>
>- `-f`: JUST DO IT!

#### $ `rsync`

Used to copy files from/to remote hosts.

`rsync user@hostname:/folder/mifyle.temp .`

### System management

#### $ `strace <command>`

Used to trace all the system calls  that a command performs.

#### $ `hostnamectl`

Used to read and modify the systen hostname

#### $ `df`

Check file system disk space usage

- `-h`: "Human" readable format, basically show mb,kb and gb

### Users management

#### $ `su <user_name>`

Switch user

#### $ `w`

Prints the logged users, including yourself, more verbose than `who`

#### $ `who`

Same as the previous one, but shorter output.

#### $ `top`

Watch processes

### Networking

#### $ `netstat`

Prints network connections, routing tables, interface statistics, masquerade connections and multicast mermerships

- `-t`: TCP
- `-a`: Display all listening and not listening sockets.
- `-u`: UDP
- `-p`: Program attached to port (Using it and listening), this will print information only if the command is run by root.
- `-l`: Listening ports
- `-n`: Numeric

#### $ `ssh`

> Program to logging into a remote machine and for executing commands on a remote machine.

- `-i "<private_ssh_key_file_name>"`: Identity File path

## Stdout, Stdin and Stderr redirection

### POSIX File descriptors

|Int value | Name | <stdio.h> file stream|
|----------|------|----------------------|
|0|Standard input| **stdin**|
|1|Standard output| **stdout**|
|2|Standard error| **stderr**|

### Stdout redirection `>`

The `>` sign is used for redirecting a program's output to something other than ***stdout*** (*standard output*, which is the terminal by default). Normally, a file or stream is expected after this operator.

```bash
echo "Hello World!" > hello.txt # This will overwrite the file.
echo "Hello World!" >> hello.txt # This will append to the file.
```

Both `>` and `>>` will attemp to create the file if doesn't exist.

### Stdin redirection `<`

The `<` symbol is used to redirect input to a program's ***stdin***.

`&>`re-directs output of one file to another.

### Stderr redirection `2>`

When a program fails, it normally outputs the error to `stdout`, but you can override this behaviour with `2>`.

```bash
png # This will throw something like "bash: png: command not found
png 2> error.txt # This will redirect the stderr to the file error.txt
```

### Redirection vs Pipes

You can do interesting stuff with redirection, for example:

```bash
netstat > output.txt && cat < output.txt
```
This command will do the following:
1. Run `netstat` program
2. Write `netstat`'s output  to `output.txt`
3. Take the `output.txt` content and send it to `cat`'s stdin.

A kinda long process right?

The same thing could be achieved (Without the need of a file) by this command:

```bash
netstat | cat
```

Which lead us to the next topic.

### Pipes `|`



## Services

Control groups, usually referred to as cgroups, are a Linux
       kernel feature which allow processes to be organized into
       hierarchical groups whose usage of various types of resources can
       then be limited and monitored.  The kernel's cgroup interface is
       provided through a pseudo-filesystem called cgroupfs.  Grouping
       is implemented in the core cgroup kernel code, while resource
       tracking and limits are implemented in a set of per-resource-type
       subsystems (memory, CPU, and so on).
## File system


### Inodes

Files are just an entry that is composed by the file name and it's inode number, example:

```bash
ls -i # With this, we are asking to list all the files and directories in the current directories and also show each one with it's inode value at the left

# Output:
864 desktop   3130 Downloads 
```

dig

traceroute


Inodes contains information about:

- Size of the file
- Location of the file (On disk)
- Permissions
- Owner
- Group owner
- Creation/Modification/Access time
- Reference count (How many hardlinks points to this file)

### Linux Service Management

Services are stored in `/etc/init.d`, this is a daemon which is the first process of the Linux system.

Start a service: `/etc/init.d/ssh start`
Stop a service: `/etc/init.d/ssh stop`

## Networking

`0.0.0.0:80` Means visible from the outside on port 80.


### Socket vs Port

***Socket***: The word “Socket” is the combination of port and IP address. It is used to identify both a machine and a service within the machine.

***Port***: The word “Port” is the number used by particular software.The same port number can be used in different computer running on same software.