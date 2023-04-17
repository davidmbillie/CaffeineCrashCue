# Caffeine Crash Cue

Caffeine Crash Cue is a Xamarin Android app that allows users to calculate an estimated caffeine crash time from a source and quantity of caffeine, along with personal factors that can affect metabolism. The provided sources include common types of coffee, tea, and energy drinks, as well as a page that allows custom inputs. The last page provides the user with the calculated time, as well as a button that can set a notification 20 minutes beforehand. Once the notification is set, the crash time will be shown on the first page of the app and on your phone's lock screen.

https://play.google.com/store/apps/details?id=com.davidmbillie.CaffeineCrashCue

## Appium Tests

This repo also provides an example of using Appium with C#. The fixtures contain smoke tests for verifying that a crash time was calculated and that a notification was properly set. One fixture can be run locally, and the other will be run during CI via Github Actions and SauceLabs.
They can be found [in the e2e folder](./e2e/CaffeineCrashCueE2E) along with a separate project for POMs.
