# Caffeine Crash Cue

Caffeine Crash Cue is a Xamarin Android app that allows users to calculate an estimated caffeine crash time from a source and quantity of caffeine, along with personal factors that can affect metabolism. The provided sources include common types of coffee, tea, and energy drinks, as well as a page that allows custom inputs. The last page provides the user with the calculated time, as well as a button that can set a notification 20 minutes beforehand. Once the notification is set, the crash time will be shown on the first page of the app and on your phone's lock screen.

This isn't quite a health app - the inspiration for making this came from the multiple times I forgot when I last had caffeine, and also the continued curiosity of the optimal time I should have my next dose.

It can be downloaded from the app store [here](https://play.google.com/store/apps/details?id=com.davidmbillie.CaffeineCrashCue).

## Appium Tests

This repo also provides an example of using Appium with C#. The fixture contain smoke tests for verifying that a crash time was calculated and that a notification was properly set. The tests are able to run on either a local Appium server or Sauce Labs depending on the configuration of certain environment variables. The main use of Sauce Labs is running the smoke tests in CI, and the workflow file can be found [here](https://github.com/HylandSoftware/Hot-Potato/blob/master/.github/workflows/ci.yml). The test projects as well as more information about them can be found in [in the e2e folder](./e2e/CaffeineCrashCueE2E).
