#!/bin/sh
osascript -e 'display notification "The Shell Process generate.sh is running" with title "SHELL_PROCESS"'
echo If filename.txt existed it does not anymore!;
rm -f filename.txt;
echo running that stuff!;
java RG;
echo Shell has DONE that stuff!;
echo Have a nice day!;