#!/bin/bash
sudo buildah build-using-dockerfile -t smashapi
sudo podman save smashapi | sudo -u cslaf podman load
podman pod rm smash-api -f
podman-compose up
