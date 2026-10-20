# Baobab Ridge Wildlife Rehabilitation System

## Project Overview
The **Baobab Ridge Wildlife Rehabilitation System** is a Windows Forms (.NET C#) desktop application designed to manage, classify, and track wildlife patient records at the rehabilitation facility.

---

## Team Members & Student Numbers
* **Nhlamulo Ngwana** – *Student Number: 603014*
* **Ntalo Mashimbye** – *Student Number: 605104*
* **Thato Ramosepele** – *Student Number: 603617*

---

## How to Build and Run the Program

1. **Prerequisites:**
   * Microsoft Visual Studio 2022 (or later) with the **.NET Desktop Development** workload installed.
   * .NET Runtime (.NET 6.0 / 8.0).

2. **Steps to Build & Execute:**
   * Clone or download the repository to your local machine.
   * Open `BaobabRidgeWildlifeRehabilitation_RS.sln` in Visual Studio.
   * Verify that `animals.txt` in the solution properties is set to **`Copy if newer`** under *Copy to Output Directory*.
   * Press **`Ctrl + Shift + B`** (or go to **Build > Build Solution**) to compile the project.
   * Press **`F5`** (or click the green **Start** button) to run the application.

---

## List of Features & Interface Controls

* **Central Health Classification Logic:**
  * Automatically calculates **Health Status** (*Critical, Serious, Recovering, Release-Ready*) and assigns appropriate **Housing Units** (*ICU, High-Dependency Ward, Outdoor Enclosure, Pre-Release Camp*) based on a recovery score (0 - 100).

### Form Buttons & User Interface Actions
* **`Add Animal` Button (`btnAddAnimal`):**
  * Validates all input textboxes (ID format `WR-XXXX`, non-negative age, recovery score between 0-100).
  * Calculates health status and housing unit dynamically.
  * Appends new patient records directly to `animals.txt` and refreshes the display grid.
* **`Search / Filter` Button (`btnSearch`):**
  * Queries the records by Animal ID or Species to highlight or isolate specific patients in the display grid.
* **`Update Animal` Button (`btnUpdate`):**
  * Modifies existing patient records (e.g., updating recovery scores and recalculated housing units) and rewrites the updated dataset to `animals.txt`.
* **`Clear Inputs` Button (`btnClear`):**
  * Resets all input textboxes and brings cursor focus back to the ID input field for quick data entry.
* **`Refresh Data / Load` Button (`btnRefresh`):**
  * Reloads all records from `animals.txt` into the `DataGridView` to ensure the display reflects the latest stored data.
* **`View Summary / Statistics` Button (`btnSummary`):**
  * Displays aggregate statistics, showing total animal counts categorized by health status and active housing facility usage.

---

## Description of File Formats

The application reads and writes data using plain text persistence with pipe (`|`) delimiter separation:

### Primary Data File: `animals.txt`
* **Delimiter:** Pipe (`|`)
* **Format Structure:**
  `AnimalID|Name|Species|Age|RecoveryScore|HealthStatus|HousingUnit`
* **Example Row:**
  `WR-0001|Thabo|African Penguin|4|85|Release-Ready|Pre-Release Camp`

---

## Known Limitations

1. **Local File Persistence:** Data is stored locally in `animals.txt`. Concurrent write operations across multiple workstations are not natively synchronized without a database server.
2. **Strict File Formatting:** Manual modifications directly to `animals.txt` that omit pipe separators or introduce missing fields will cause parsing errors when loading records into the application.
