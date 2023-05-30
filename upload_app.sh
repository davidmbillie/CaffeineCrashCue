# https://docs.saucelabs.com/dev/api/storage/

curl -f -u "$SAUCE_USERNAME:$SAUCE_ACCESS_KEY" --location \
--request POST 'https://api.us-west-1.saucelabs.com/v1/storage/upload' \
--form 'payload=@"./CaffeineCrashCue/CaffeineCrashCue.Android/bin/Release/com.davidmbillie.CaffeineCrashCue.aab"' \
--form 'name="com.davidmbillie.CaffeineCrashCue.aab"'