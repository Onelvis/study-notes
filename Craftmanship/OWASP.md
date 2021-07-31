# OWASP
- [OWASP](#owasp)
	- [## What is OWASP?](#-what-is-owasp)
	- [## OWASP Top 10](#-owasp-top-10)
	- [1 . A1 Injection](#1--a1-injection)
	- [2. Broken Authentication](#2-broken-authentication)
	- [3. Sensitive Data](#3-sensitive-data)
	- [Scenarios](#scenarios)
	- [How to avoid](#how-to-avoid)
- [4. XML External Entities (XXE)](#4-xml-external-entities-xxe)
	- [How to avoid](#how-to-avoid-1)
- [5. Broken Access Control](#5-broken-access-control)
	- [Common access control vulnerabilities](#common-access-control-vulnerabilities)
	- [Scenarios](#scenarios-1)
		- [1. The application uses unverified data in a SQL call that is accessing account information](#1-the-application-uses-unverified-data-in-a-sql-call-that-is-accessing-account-information)
		- [2. An attacker simply forces browsers to target URLs. Admin rights are required for access to the admin page.](#2-an-attacker-simply-forces-browsers-to-target-urls-admin-rights-are-required-for-access-to-the-admin-page)
	- [How to avoid](#how-to-avoid-2)
- [6. Security misconfiguration](#6-security-misconfiguration)
	- [Vulnerabilities](#vulnerabilities)
	- [Scenarios](#scenarios-2)
		- [1. The application server comes with sample applications that are not removed from the production serverl..](#1-the-application-server-comes-with-sample-applications-that-are-not-removed-from-the-production-serverl)
		- [2. Directory listing is not disabled on the server. An attacker discovers they can simply list directories, the attacker finds and downloads the compiled Java classes.](#2-directory-listing-is-not-disabled-on-the-server-an-attacker-discovers-they-can-simply-list-directories-the-attacker-finds-and-downloads-the-compiled-java-classes)
		- [3. The application server's configuration allows detailed error messages.](#3-the-application-servers-configuration-allows-detailed-error-messages)
		- [4. A cloud service provider has default sharing permissions open to user internet by other CSP users.](#4-a-cloud-service-provider-has-default-sharing-permissions-open-to-user-internet-by-other-csp-users)
	- [How to avoid](#how-to-avoid-3)
- [7. Cross-site scripting (XSS)](#7-cross-site-scripting-xss)
	- [Reflected XSS](#reflected-xss)
	- [Stored XXS](#stored-xxs)
	- [DOM XSS](#dom-xss)
	- [Typical XSS attacks](#typical-xss-attacks)
	- [Scenarios](#scenarios-3)
	- [How to avoid](#how-to-avoid-4)
- [8. Insecure deserialization](#8-insecure-deserialization)
	- [Scenarios](#scenarios-4)
	- [How to avoid](#how-to-avoid-5)
- [9. Using components with known vulnerabilities](#9-using-components-with-known-vulnerabilities)
- [10. Insufficient logging and monitoring](#10-insufficient-logging-and-monitoring)
## What is OWASP?
---
Stands for the **Open Web Application Security Project**, which is focused on making security visible and effective within web-based software applications, helping organizations around the world make better decisions about application security risks.

## OWASP Top 10
---
> Includes the ten most dangerous current web aaplication security flaws, and effective methods for remediating them.



## 1 . A1 Injection

 An application is vulnerable to injection attack when: 
 - User-supplied data is not validated, filtered, or sanitized by the application
 - Hostile data is used within object-relational mapping (ORM) search parameters to extrad additional records
 - Hostile data is directly used or concatenated, such that the SQL or command contains both structure and hostile data in dynamic queries, commands or stored procedures.

## 2. Broken Authentication

An application is vulnerable to broken authentication when :

- Permits automated attack such as **credential stuffing**, where the attacker has a list of valid usernames and passwords
- Permits fruce force attacks
- Permits default, weak or well-known passwords, such as `Password1` or `admin/admin`
- Uses weak or ineffective credential recovery and forgotpassword processes, such as **knowledge-based answer**
- Uses plain text, encrypted, or weakly hashed password
- Has missing or ineffective multi-factor authentication
- Exposes session Ids in the URL
- Does not rotate session IDs after successful login
- Does not properly invalidate session IDs
- Sesion timeouts aren't set properly

## 3. Sensitive Data

> The most common flaw is simply not encrypting sensitive data.

- Sensitive Personally Identifiable Information **(PII)**
  - Health records
  - Credentials
  - Personal data
  - Credit cards
- Consider the following when wondering about security of this type of data:
  - Is any data transmited in clear text?
  - Is sentitive data stored in clear text, including backups?
  - Are any old or weak cryptographic algorithms used either by default or in older code?
  - Are default crypto keys in use, re-used?
  - Is ecryption not enforced?
  - Does the agent not verify if the received server certificate is valid?
   
  ## Scenarios
    > 1. An application encrypts credit card numbers in a database using automatic database encryption. However, this data is automatically decrypted when retrieved, allowing an SQL injection flaw to retrieve credit card numbers in clear text.

    > 2. A site doesn't user or enforce TLS for all pages or supports weak encryption. An attacker monitors network traffic (As at an insecure wireless network), downgrades connection from HTTPS to HTTP, intercepts requests, and steals the user's session cookie. The attacker then replays this cookie and hijacks the user's authenticated session, accessing or modifying the user's private data. Instead of the above, they could alter all transported data, e.g. the recipient of a money transfer.

    > 3. The password database uses unsalted or simple hashes to store everyone's paswords. A file upload flaw allows an attacker to retrieve the password database. All the unsalted hashes can be exposed with a rainbow table of pre-calculated hashes. Hashes generated by simple or fast hash functions may be cracked by GPU's, even if the were salted.
    
  ## How to avoid
    1. Classify data processed stored, or transmitted by an application and Identify which data is sentitive according to privacy laws, regulatory requirements, or bussiness needs.
    2. Apply controls as per the classification.
    3. Don't store sensitive data unnecessarily
    4. Make sure to encrypt all sensitive data at rest
    5. Ensure up-to-date and strong standard algorithms, protocols and keys are in place; use proper key management.
    6. Encrypt all data transit with secure protocols, such as TLS
    7. Disable caching for responses that contain sensitive data
    8. Store passwords using strong adaptive and salted hashing functions with a work factor.

# 4. XML External Entities (XXE)

> Attackers can exploit vulnerable XML processors if they can upload XML or include hostile content in an XML document, exploiting vulnerable code, dependencies or integrations.

> SAML uses XML for identity assertions, and may be vulnerable.
> Being vulnerable to XXE attacks likely means that the application is vulnerable to denial of service attacks including **the billion laughs attack**
  ## How to avoid
  1. Avoid direct upload of `.XML` files
  2. Don't allow untrusted data to be inserted into XML documents that will be parsed by a XML processor.
  3. User less complex data formats such as JSON, and avoid serialization of ***sensitive data***
  4. Patch or upgrade all XML processors and libraries in sue by the application or on the underlying operating system.
  5. Disable XML external entity and DTD processing in all XML parsers in the application, as per the OWASP cheat sheet 'XEE prevention'
  6. Implement positive server-side input validation, filtering or sanitization to prevent hostile data within XML documents, headers, or nodes.
  7. Verify that XML or XSL file upload functionality validates incoming XML using XSD validation or similar

# 5. Broken Access Control 
> Acess control enforces policy such that user cannot act outside of their intended permissions.
  ## Common access control vulnerabilities
  * Bypassing access control checks by modifying the URL, internal application state, or the HTML page.
  * Allowing the primary key to be changed to another user's record, permiting viewing or editing someone else's account.
  * Elevation of privilege. Acting as user without being logged in, or acting as an admin.
  * Metadata manipulation, such as replaying or tampering with JSON web token, acess control token or a cookie or hidden field manipulated to elevate privilages, or abusing JWT invalidation.
  * **CORS** misconfiguration allows unauthorized API access
  * Force browsing to authenticated pages as an unauthenticated user or to privileged pages as a standard user.

  ## Scenarios
  ### 1. The application uses unverified data in a SQL call that is accessing account information
  ```javascript
    pstmt.setString(1, request.getParameter("acct"));
    ResultSet results = pstmt.ExecuteQuery();
  ```
  ### 2. An attacker simply forces browsers to target URLs. Admin rights are required for access to the admin page.

  ## How to avoid
  1. Implement access control mechanisms once and re-use them throughout the application, including minimizing CORS usage
  2. Model access controls should enforce record ownership, rather than accepting that the user can create, read, update or delete any record
  3. Unique application bussiness limit requirements should be enforced by domain models
  4. Disable web server directory listing an ensure file metadata and backup files are not present within web roots
  5. Log access control failures, alert admins when appropiate
  6. Rate limit API and controller access to minimize the harm from automated attack tooling
  7. JWT tokens hould be invalidate on the server after logout
  8. Developers and QA staff should include functional access control unit and integration tests


  # 6. Security misconfiguration

  > Security misconfiguration can happen at any level of any application stack, including the nertwork services, platform, web server, application server, database, frameworks, custom code, and pre-installed virtual machine, containers, or storage
    

  ## Vulnerabilities

  * Missing appropiate security hardening across any part of the application stack, or improperly configured permissions on cloud services. 
  * Unnecesary features are enabled or installed (unnecesary ports, services, pages, accounts, or privileges)
  * Default accounts and their password still enabled and unchanged
  * Error handling reveals stack traces or other overly informative error messages to users
  * Form upgraded systems, latest security features are disabled or not configured securely
  * The security settings in the application servers, application frameworks, libraries, databases, not set to secure values
  * The server does not send security headers or directives, or they are not set to secure values
  * The software is out of date or vulnerable
  
  ## Scenarios

  ### 1. The application server comes with sample applications that are not removed from the production serverl..
  ### 2. Directory listing is not disabled on the server. An attacker discovers they can simply list directories, the attacker finds and downloads the compiled Java classes.
  ### 3. The application server's configuration allows detailed error messages.
  ### 4. A cloud service provider has default sharing permissions open to user internet by other CSP users.

  ## How to avoid

  1. Implement a repeatable hardening process that makes it fast and easy to deploy another environment that is properly locked down. Development, QA and production environments should be all configured identically.
  2. Implement a minimal platform without any unnecesary features, components, documentation and samples
  3. Implement a task to review and update the configurations appropiate to all security notes, updates and patches as part of the patch management process.
  4. Implement a segmented application architecture that provides effective, secure separation between components or tenants, with segmentation, containerization, or cloud security groups.
  5. Implement an automated process to verify the effectiveness of the configurations and settings in all environments
   
  # 7. Cross-site scripting (XSS)
  
  > Of the three forms of XSS, the impact of XSS is moderate for both Reflected XSS and DOM XSS, and the impact is server for Stored XSS.

  ## Reflected XSS
  The application or API includes unvalidated and unescaped user input as part of HTML output. A successful attack can allow the attacker to execute arbitrary HTML and JavaScript in the victim's browser.

  ## Stored XXS
  The application or API stores unsanitized user input that is viewed at a later time by other user or an administrator.

  ## DOM XSS
  Javascript frameworks, single-page applications, and APIs that dynamically include attacker-controllable data to a apages, are vulnerable to DOM XSS.

  ## Typical XSS attacks
    - Session stealing
    - Account takeover
    - MFA bypass
    - DOM node replacement
    - Key logging

  ## Scenarios
  1. The application uses untrusted data in the construction of the following HTML snippet without validation or escaping:
     ```js
     (String) page += "<input name='creditcard' type="TEXT" value='"+ request.getParameter("CC")+"'>";
     ```
     This is a perfect example of code and data mixture. Is the last parameter `"'>";` a program or data?
     In this case the browser gets confused because it cannot differentiate code and data. This is why all data must be treated as untrusted
  
  ## How to avoid
  1. Use framework that automatically escape XSS by design.
  2. Escaping untrusted HTTP request data based on the context in the HTML output will resolve reflected and stored XSS vulnerabilities. 
  3. Applying context-sensitive encoding when modifying the broweser document on the client side acts against DOM XSS
  4. Enabling a content security policy (CSP) is a defense-in-depth mitigatting control against XSS. 
   
  # 8. Insecure deserialization

  > Application and APIs will be vulnerable if they desirealize hostile or tampered objects supplied by an attacker.

  ## Scenarios
  1. A React application calls a set of Spring Boot microservices. Being functional programmers, they tried to ensure that their code is immutable. The solution they came up with is serializing user state and passing it back and forth with each request. An attacker notices the "R00" Java object signature, and usees the Java serial killer tool to gain remote code execution on the application server.
  2. A PHP forum uses PHP object serialization to save a "super" cookie, containing the user's user ID, role, password hash, and other state

  ## How to avoid
  1. Not accept serialized objects from untrusted sources, nor use serialization mediums that only permit primitive data types.
  2. Implement integrity checks such as digital signatures on any serialized objects to prevent hostile object creation.
  3. Enforce strict type constraints during deserialization before object creation as the code typically expects a definable set of classes.
  4. Isolating and running code that deserializes in low privilege environments.
  5. Logging deserialization exceptions and failures.
  6. Restricting or monitoring incoming and outgoing network connectivity from containers.
  7. Monitoring deserialization, alert if a user deserializes constantly.

  # 9. Using components with known vulnerabilities

  - Check the versions of the components that you use:
    - OS
    - Web/application server
    - Databases management systems
    - Applications
    - APIs
    - Components
    - Runtime environments
  - Remove unnused dependencies
  
  # 10. Insufficient logging and monitoring
  > Self explanatory