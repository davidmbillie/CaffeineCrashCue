# Caffeine Crash Cue Appium Tests

This folder contains the end-to-end Appium smoke tests and Page Object Models for the app. The smoke tests represent the most critical functions of the app - the ability to set a notification and the ability to display a crash time. The [fixture](./CaffeineCrashCue.E2E/BaseFixture.cs) is able to be configured to be run on either a local Appium server or through a Sauce Labs emulator/device via the following environment variables:

`IS_SAUCE` : Set to `true` to perform some Sauce Labs-specific setup, set to `false` for local runs

`DEVICE_NAME`: Name of the device/emulator of the system under test such as "Google Pixel 4a GoogleAPI Emulator"

`PLATFORM_VERSION`: The numerical Android version such as "11.0"

`SAUCE_USERNAME`: Your Sauce Labs username that should be stored as a secret (only checked when `IS_SAUCE` is `true`)

`SAUCE_ACCESS_KEY`: Your personal Sauce Labs access key that should be stored as a secret (only checked when `IS_SAUCE` is `true`)

## Local Environment Variable Setup

When I run tests locally, I set the `IS_SAUCE`, `DEVICE_NAME`, `PLATFORM_VERSION` variables through a runsettings file such as [local11.runsettings](./local11.runsettings). I set the `SAUCE_USERNAME` and `SAUCE_ACESS_KEY` via Visual Studio's built-in Secret Manager. More information can be found here: https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows/.

## CI Environment Variable Setup

I run these tests through CI via Github Actions, and the workflow file can be found [here](../../.github/workflows/ci.yml). I set `IS_SAUCE`, `DEVICE_NAME`, `PLATFORM_VERSION` inline, and access `SAUCE_USERNAME` and `SAUCE_ACESS_KEY` via Github Actions secrets. More information can be found here: https://docs.github.com/en/actions/security-guides/encrypted-secrets/. My phone and go-to local Android emulator run on Android 11.0, so I configured the workflow file to run the two other most recent plaform versions in Sauce Labs.
