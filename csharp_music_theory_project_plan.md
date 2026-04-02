# C# Project Plan — Music Key / Chord Helper

## Project Goal

Build a C# app that helps a user with three music theory tasks:

1. **Note Input Mode**  
   The user types in a set of notes, and the app returns:
   - possible matching **key signatures**
   - possible matching **chords**

2. **Key Notes Mode**  
   The user asks for a key, and the app returns:
   - all notes in that key

3. **Related Keys Mode**  
   The user asks for a key, and the app returns:
   - similar or closely related keys
   - relative major / minor
   - optionally neighboring keys on the circle of fifths

---

## Recommended App Type

Start with a **Console App** in C#.

Why:
- easiest to build first
- simple for testing logic
- good for learning project structure
- can later be upgraded to WinForms, WPF, or web app

---

## Suggested Solution Structure

```text
MusicTheoryHelper/
│
├── MusicTheoryHelper.sln
│
├── MusicTheoryHelper.Console/
│   ├── Program.cs
│   ├── App.cs
│   └── Menu/
│       └── MainMenu.cs
│
├── MusicTheoryHelper.Core/
│   ├── Models/
│   │   ├── Note.cs
│   │   ├── Scale.cs
│   │   ├── Chord.cs
│   │   ├── KeySignature.cs
│   │   ├── AnalysisResult.cs
│   │   └── RelatedKeyResult.cs
│   │
│   ├── Enums/
│   │   ├── NoteName.cs
│   │   ├── AccidentalType.cs
│   │   ├── ScaleType.cs
│   │   └── ChordType.cs
│   │
│   ├── Services/
│   │   ├── NoteParserService.cs
│   │   ├── KeyService.cs
│   │   ├── ChordService.cs
│   │   ├── KeyAnalysisService.cs
│   │   ├── RelatedKeyService.cs
│   │   └── MusicTheoryDataService.cs
│   │
│   ├── Data/
│   │   ├── KeyLibrary.cs
│   │   ├── ChordLibrary.cs
│   │   └── CircleOfFifthsLibrary.cs
│   │
│   ├── Helpers/
│   │   ├── NoteNormalizationHelper.cs
│   │   ├── IntervalHelper.cs
│   │   └── DisplayHelper.cs
│   │
│   └── Interfaces/
│       ├── IKeyService.cs
│       ├── IChordService.cs
│       ├── IKeyAnalysisService.cs
│       └── IRelatedKeyService.cs
│
└── MusicTheoryHelper.Tests/
    ├── NoteParserServiceTests.cs
    ├── KeyServiceTests.cs
    ├── ChordServiceTests.cs
    └── RelatedKeyServiceTests.cs
```

---

## High-Level Flow

### Mode 1 — Notes to Possible Keys and Chords

User enters notes such as:

```text
C E G
```

App should:
1. parse the input notes
2. normalize note spellings
3. compare the notes against known chord patterns
4. compare the notes against known keys
5. return possible matches

Example output:

```text
Possible chords:
- C major
- C major (root position)

Possible keys:
- C major
- A minor
- F major
```

---

### Mode 2 — Show Notes in a Key

User enters:

```text
E major
```

App should return:

```text
Notes in E major:
E, F#, G#, A, B, C#, D#
```

This mode should support:
- major keys
- minor keys
- enharmonic handling if you want to expand later

---

### Mode 3 — Show Similar / Relative Keys

User enters:

```text
A minor
```

App should return things like:

```text
Relative major:
- C major

Closely related keys:
- E minor
- D minor
- F major
- G major
```

This can be based on:
- relative major/minor
- keys with one accidental difference
- neighboring positions on the circle of fifths

---

## Core Features

### 1. Input Parsing
The program should accept notes in formats like:

- `C E G`
- `C, E, G`
- `F# A C#`
- `Bb D F`

The parser should:
- trim spaces
- split on commas or spaces
- normalize capitalization
- validate notes
- reject bad input clearly

---

### 2. Note Normalization
A helper should standardize note names so comparisons are easier.

Examples:
- `db` → `Db`
- `f#` → `F#`
- `bb` → `Bb`

Later, you may choose whether to:
- preserve exact user spelling
- convert enharmonic notes internally
  - `C#` ↔ `Db`
  - `F#` ↔ `Gb`

---

### 3. Chord Matching
Given a list of notes, compare the note set against chord formulas.

Examples:

- Major triad = root, major 3rd, perfect 5th
- Minor triad = root, minor 3rd, perfect 5th
- Diminished triad
- Augmented triad
- Dominant 7th
- Major 7th
- Minor 7th

Example:

Input:
```text
C E G
```

Possible match:
- C major

Input:
```text
A C E
```

Possible match:
- A minor

---

### 4. Key Matching
Compare the user note set against each stored key.

Logic idea:
- build a note set for every supported key
- count how many user notes appear in each key
- sort by strongest matches

Possible scoring:
- exact fit = highest score
- all notes found in key = good match
- keys containing most of the user notes = lower confidence match

Example:
Input notes:
```text
C E G
```

Possible keys:
- C major
- A minor
- F major
- G major

Because all of those keys can contain C, E, and G.

---

### 5. Key Lookup
Given a key name like `D minor`, return the full scale.

Examples:
- C major → C D E F G A B
- G major → G A B C D E F#
- A minor → A B C D E F G

This can be built from:
- hardcoded scale data at first
- interval formulas later

---

### 6. Related Key Lookup
For a requested key, return:
- relative major or minor
- neighboring keys on the circle of fifths
- optionally parallel major/minor

Example for `C major`:
- relative minor: A minor
- nearby keys: G major, F major
- optional related minors: E minor, D minor

---

## Recommended Classes

## `Program.cs`
Entry point.
- starts app
- creates services
- launches menu loop

---

## `App.cs`
Controls main program flow.
- show mode options
- read user selection
- call the correct service
- keep app running until exit

---

## `MainMenu.cs`
Responsible only for menu display and input prompts.

Example menu:
```text
1. Enter notes and find possible keys/chords
2. Show all notes in a key
3. Show related keys
4. Exit
```

---

## `Note.cs`
Represents a musical note.

Suggested properties:
```csharp
public class Note
{
    public string Name { get; set; }
}
```

Later you could expand this with:
- pitch class
- accidental
- enharmonic equivalents

---

## `Chord.cs`
Represents a chord.

Suggested properties:
```csharp
public class Chord
{
    public string Name { get; set; }
    public List<string> Notes { get; set; } = new();
    public string Formula { get; set; }
    public string ChordType { get; set; }
}
```

---

## `KeySignature.cs`
Represents a key.

Suggested properties:
```csharp
public class KeySignature
{
    public string Name { get; set; }
    public string Mode { get; set; }
    public List<string> Notes { get; set; } = new();
    public int AccidentalCount { get; set; }
}
```

---

## `AnalysisResult.cs`
Used for note-input mode.

Suggested properties:
```csharp
public class AnalysisResult
{
    public List<string> PossibleChords { get; set; } = new();
    public List<string> PossibleKeys { get; set; } = new();
}
```

---

## `RelatedKeyResult.cs`
Used for the related-keys mode.

Suggested properties:
```csharp
public class RelatedKeyResult
{
    public string RequestedKey { get; set; }
    public string RelativeKey { get; set; }
    public List<string> NeighborKeys { get; set; } = new();
    public List<string> AdditionalRelatedKeys { get; set; } = new();
}
```

---

## `NoteParserService.cs`
Responsibilities:
- parse raw user input into note tokens
- validate note names
- normalize note spelling

Suggested methods:
```csharp
public List<string> ParseNotes(string input);
public bool IsValidNote(string note);
public string NormalizeNote(string note);
```

---

## `KeyService.cs`
Responsibilities:
- return notes in a requested key
- look up key data from the library

Suggested methods:
```csharp
public KeySignature GetKey(string keyName);
public List<string> GetNotesInKey(string keyName);
public bool TryGetKey(string keyName, out KeySignature key);
```

---

## `ChordService.cs`
Responsibilities:
- compare user notes against chord definitions
- return possible chord matches

Suggested methods:
```csharp
public List<Chord> FindMatchingChords(List<string> inputNotes);
```

---

## `KeyAnalysisService.cs`
Responsibilities:
- compare user notes against keys
- rank likely key matches
- combine chord + key analysis for mode 1

Suggested methods:
```csharp
public AnalysisResult AnalyzeNotes(List<string> inputNotes);
public List<KeySignature> FindMatchingKeys(List<string> inputNotes);
```

---

## `RelatedKeyService.cs`
Responsibilities:
- find relative major/minor
- find nearby circle-of-fifths keys
- produce output for mode 3

Suggested methods:
```csharp
public RelatedKeyResult GetRelatedKeys(string keyName);
```

---

## `MusicTheoryDataService.cs`
Responsibilities:
- central place for loading music theory data
- can start as hardcoded lists
- later can load JSON files

Suggested methods:
```csharp
public List<KeySignature> GetAllKeys();
public List<Chord> GetAllChordPatterns();
```

---

## Data Design

## Option A — Hardcoded Data First
Good for a first version.

Example idea:
```csharp
new KeySignature
{
    Name = "C major",
    Mode = "Major",
    Notes = new List<string> { "C", "D", "E", "F", "G", "A", "B" },
    AccidentalCount = 0
}
```

And:
```csharp
new Chord
{
    Name = "C major",
    Notes = new List<string> { "C", "E", "G" },
    Formula = "1-3-5",
    ChordType = "Major"
}
```

---

## Option B — JSON Data Files Later
Once the logic works, move your data into JSON.

Example files:
- `keys.json`
- `chords.json`

Benefits:
- easier to edit
- easier to expand
- keeps code cleaner

---

## Example Console Interaction

```text
Select a mode:
1. Notes to keys/chords
2. Notes in a key
3. Related keys
4. Exit

Choice: 1

Enter notes:
C E G

Possible chords:
- C major

Possible keys:
- C major
- A minor
- F major
- G major
```

---

## Basic Logic Rules

## Chord Matching Rule
A chord matches if:
- all required chord notes are present in the input
- or the input exactly equals the chord note set

You may later decide whether:
- extra notes are allowed
- inversions are supported
- note order matters

For version 1:
- ignore note order
- use note sets
- do not worry about inversions yet unless you want to

---

## Key Matching Rule
A key is a possible match if:
- every user note exists in that key

Then sort by:
- exact containment
- maybe fewer accidentals first
- maybe stronger theoretical fit later

---

## Related Key Rule
For version 1, define related keys as:
- relative major/minor
- one step clockwise on circle of fifths
- one step counterclockwise on circle of fifths

Optional later:
- parallel major/minor
- diatonic neighboring minors/majors
- modal interchange suggestions

---

## Input Validation

The app should gracefully handle:
- blank input
- duplicate notes
- invalid notes like `H` or `R#`
- invalid key names like `Z major`

Examples:
```text
Invalid note entered: H
Please enter notes like: C, D#, Bb, F#
```

---

## Suggested Development Order

## Phase 1 — Skeleton
Build:
- solution
- console project
- core library
- menu loop

---

## Phase 2 — Key Data
Build:
- `KeySignature` model
- `KeyLibrary`
- `KeyService`
- mode 2 first

Why:
- this is the easiest feature
- it gives you working data to reuse later

---

## Phase 3 — Note Parser
Build:
- raw input parsing
- validation
- normalization

---

## Phase 4 — Chord Matching
Build:
- `Chord` model
- chord library
- chord match logic

Start with:
- major
- minor
- diminished
- augmented

Then add 7th chords later.

---

## Phase 5 — Key Analysis Mode
Build:
- compare note input against keys
- return possible matching keys
- combine with chord results

---

## Phase 6 — Related Keys Mode
Build:
- relative key logic
- circle of fifths neighbors
- display formatting

---

## Phase 7 — Tests
Add tests for:
- note parsing
- note validation
- known key outputs
- chord matching
- related key lookup

---

## Example Test Cases

### Notes to Chord
Input:
```text
C E G
```
Expected:
- C major

### Notes to Key
Input:
```text
A C E
```
Expected possible keys include:
- A minor
- C major
- F major

### Key Lookup
Input:
```text
G major
```
Expected:
```text
G, A, B, C, D, E, F#
```

### Related Keys
Input:
```text
E minor
```
Expected:
- relative major: G major
- nearby keys: B minor, A minor, D major, C major depending on your rule set

---

## Future Upgrades

Later, the app could support:
- chord inversions
- slash chords
- enharmonic equivalents
- modes
- pentatonic and blues scales
- roman numeral analysis
- GUI version
- MIDI note input
- guitar fretboard display
- piano keyboard display

---

## Good First Version Scope

Keep version 1 small.

### Support:
- all 12 major keys
- all 12 natural minor keys
- major and minor triads
- diminished and augmented triads
- basic relative key lookup

### Skip for now:
- double sharps / double flats
- exotic scales
- advanced jazz chord naming
- modal interchange
- borrowed chords

---

## Suggested Interface Contracts

```csharp
public interface IKeyService
{
    List<string> GetNotesInKey(string keyName);
    bool TryGetKey(string keyName, out KeySignature key);
}
```

```csharp
public interface IChordService
{
    List<Chord> FindMatchingChords(List<string> inputNotes);
}
```

```csharp
public interface IKeyAnalysisService
{
    AnalysisResult AnalyzeNotes(List<string> inputNotes);
}
```

```csharp
public interface IRelatedKeyService
{
    RelatedKeyResult GetRelatedKeys(string keyName);
}
```

---

## Final Recommendation

Build this in this order:

1. **Mode 2 first** — show notes in a key  
2. **Mode 3 second** — show related keys  
3. **Mode 1 last** — analyze user notes into possible chords and keys  

That order is best because:
- it starts with the simplest logic
- it creates reusable key data
- it reduces confusion
- it gives you fast progress early

---

## Optional Mini Example of Program Flow

```csharp
while (true)
{
    Console.WriteLine("1. Notes to keys/chords");
    Console.WriteLine("2. Notes in a key");
    Console.WriteLine("3. Related keys");
    Console.WriteLine("4. Exit");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            // prompt for notes
            // parse notes
            // analyze
            break;

        case "2":
            // prompt for key
            // show notes
            break;

        case "3":
            // prompt for key
            // show related keys
            break;

        case "4":
            return;
    }
}
```

---

## Deliverable Summary

This project should have:
- a console UI
- a clean `Core` library for music logic
- separate services for parsing, chord matching, key lookup, and related keys
- tests for each main feature
- simple hardcoded data first, then JSON later

That gives you a clean, expandable C# project without making the first version too complicated.
