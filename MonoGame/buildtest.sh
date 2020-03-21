#!/bin/bash
msbuild TestWebGame/TestWebGame.csproj
rm -rf /var/www/html/TestWebGame
cp -R TestWebGame/bin/Debug/net47 /var/www/html/TestWebGame
