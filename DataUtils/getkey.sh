#!/bin/bash
user=string
pw=stringstring

curl -k -X POST -H 'Content-Type: application/json' -d '{username: "string", password: "stringstring"}' https://localhost:5501/api/auth/login > jwt.key
