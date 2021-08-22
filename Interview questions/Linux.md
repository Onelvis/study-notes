# Linux interview questions

## How would you connect to a cloud machine and open an interactive shell?

## How would you copy a file from the ssh machine to your actual machine?

Using rsync.

## How would you manage services?

Systemctl (systemd) 

`systemctl start nginx`

## Enable vs Start service

Starting is one-time, Enabling is boot-time (Persistent).


## du vs df

df let's you know the disk usage, where as du let's you know the amount of space taken by the specified file/directory.

`du -sh /var/log/*`

## What is a mount?

## What is a init system?

Basics of systemd. 

## What is `/proc`

Is like the kernel state "filesystemized".

## Process troubleshooting

- Use ps to show information about running processes. like: `ps aux | grep <keyword>`

- Find the config files that are visible with the last said command, if not, play around with `/proc`

## Networking

- Use `netstat` or `ss` to gather information about ports and general conections. 


## What can prevent you to be able to create a file?

- Incorrect ownership
- Incorrect permissions

keyword: inodes exhaustion

## What are inodes?



`df -i`

## How would you manage the configuration of a certain executable?

- Configuration managers
- Packer?
- Licenses keys management (vault)

## How would you setup a scheduled task on linux?

1. `crontab -e`
2. `0 10 * * * sh myscript.sh`