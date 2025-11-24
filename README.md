Code quest
## 🎮 Detailed Game Description

### Core Gameplay Features
- **Character Development**: Train your wizard, earn power points, and achieve prestigious ranks
- **Strategic Combat**: Battle diverse monsters using dice-based mechanics with visual ASCII art
- **Resource Management**: Mine for bits (in-game currency) in a tactical grid-based mini-game
- **Economic System**: Purchase magical items and manage your inventory
- **Progression Unlocks**: Gain powerful spells as you level up from 1 to 5
- **Ancient Mysteries**: Decode magical scrolls through text manipulation challenges


## 🚀 Execution Instructions

### Prerequisites

- **Visual Studio 2022** or **Visual Studio Code** with C# extension
- **Windows/Linux/macOS** with .NET SDK installed

### Compilation & Execution

### Chapter 1: Train Your Wizard

| Test Case | Input | Expected Output | Variables State |
|-----------|-------|-----------------|-----------------|
| **Normal** | Name: "john"<br>Training: Random EXP | Name capitalized to "John"<br>Rank assigned based on total EXP | `name = "John"`<br>`totalexp = 15-120`<br>`Title = Rank1-Rank5` |
| **Boundary** | Name: "a"<br>Training: Mixed EXP | Name: "A"<br>Borderline rank (e.g., 19, 29, 34, 39 EXP) | `name = "A"`<br>`totalexp = 19/29/34/39`<br>`Title = Appropriate rank` |
| **Error** | Name: "" (empty)<br>Training: Normal | Default name "Unknown"<br>Training continues normally | `name = "Unknown"`<br>`totalexp = accumulated`<br>`Title = Based on EXP` |

### Chapter 2: Increase LVL (Combat)

| Test Case | Input | Expected Output | Variables State |
|-----------|-------|-----------------|-----------------|
| **Normal** | Monster: Forest Goblin (5 HP)<br>Dice: 3, 2 | Monster defeated in 2-3 turns<br>Level increases by 1 | `enemyHealth = 0`<br>`lvl = previous + 1`<br>`dice = random 1-6` |
| **Boundary** | Monster: Ancient Dragon (50 HP)<br>Dice: All 6's | Long combat (9+ turns)<br>Max level reached (5) | `enemyHealth = 0`<br>`lvl = 5 (max)`<br>`turns = 9+` |
| **Error** | Already level 5<br>Try to fight | "You are already max lvl"<br>No combat initiated | `lvl = 5`<br>`enemyHealth = unchanged`<br>No level increase |

### Chapter 3: Loot the Mine

| Test Case | Input | Expected Output | Variables State |
|-----------|-------|-----------------|-----------------|
| **Normal** | Coords: (2,2), (0,4), (3,1)<br>5 attempts | Find 2-3 coins<br>Earn 10-150 bits total | `Bits = +earned`<br>`tries = 5`<br>`coinsFound = 2-3` |
| **Boundary** | Coords: (0,0), (4,4), (0,4), (4,0), (2,2)<br>All corners | Various results based on coin placement<br>Uses all attempts | `Bits = variable`<br>`tries = 0`<br>Grid fully explored |
| **Error** | Coords: (5,5), (-1,2), (a,b)<br>Invalid inputs | "Out of range" or "Invalid format"<br>Attempts still consumed | `tries = decreased`<br>`Bits = unchanged`<br>Error messages shown |

### Chapter 4: Show Inventory

| Test Case | Input | Expected Output | Variables State |
|-----------|-------|-----------------|-----------------|
| **Normal** | Inventory: ["Iron Dagger", "Healing Potion"] | Display 2 items with names<br>Clear formatting | `inventory.length = 2`<br>Items displayed correctly |
| **Boundary** | Inventory: [] (empty) | "Your inventory is currently empty"<br>Clear empty state message | `inventory.length = 0`<br>Empty array handled |
| **Error** | Inventory: null (theoretical)<br>Access attempt | Graceful handling<br>Default to empty display | Fallback to empty state<br>No crashes |

### Chapter 5: Buy Items

| Test Case | Input | Expected Output | Variables State |
|-----------|-------|-----------------|-----------------|
| **Normal** | Bits: 100<br>Buy: Healing Potion (10) | Purchase successful<br>Bits: 90<br>Item added to inventory | `Bits = 90`<br>`inventory.length +1`<br>Item in inventory |
| **Boundary** | Bits: 30<br>Buy: Iron Dagger (30) | Purchase successful<br>Bits: 0 (exact amount)<br>Item added | `Bits = 0`<br>Exact cost transaction<br>Inventory updated |
| **Error** | Bits: 5<br>Buy: Crossbow (40) | "You don't have enough bits"<br>Purchase denied<br>Bits unchanged | `Bits = 5`<br>`inventory.length unchanged`<br>Error message shown |

### Chapter 6: Show Attacks

| Test Case | Input | Expected Output | Variables State |
|-----------|-------|-----------------|-----------------|
| **Normal** | Level: 3 | Display levels 1-3 attacks<br>8 total spells shown<br>Proper formatting | `lvl = 3`<br>Attacks from levels 1,2,3<br>Clear level headers |
| **Boundary** | Level: 1<br>Level: 5 | Minimal spells (1)<br>All spells (12)<br>Appropriate display | `lvl = 1 or 5`<br>Correct spell count<br>Level boundaries respected |
| **Error** | Level: 0 (impossible)<br>Level: 6 (impossible) | Default to level 1 or max 5<br>Graceful fallback<br>No crashes | `lvl = clamped 1-5`<br>Safe display<br>Error prevention |

## Chapter 1: Train Your Wizard
**Primary Function**: Character creation and initial progression system

**What it does**:
- Captures the player's wizard name and automatically capitalizes it (first letter uppercase, rest lowercase)
- Simulates a 5-day training period where each day generates:
  - Random training hours (1-24)
  - Random power points earned (1-10)
- Calculates total accumulated power points across all training days
- Assigns one of five wizard ranks based on total points:
  - <20 points: Raoden el Elantrí - "Repeating 2nd semester"
  - 20-29 points: Zyn el Buguejat - "Still confusing wand with spoon"
  - 30-34 points: Arka Nullpointer - "Breeze Magic Summoner"
  - 35-39 points: Elarion de les Brases - "Can summon dragons without burning lab"
  - ≥40 points: ITB-Wizard el Gris - "Master of Arcane Arts"

**Purpose**: Establishes player identity and provides initial character progression with humorous rank descriptions that reflect academic struggles in a magical context.

## Chapter 2: Increase LVL (Combat System)
**Primary Function**: Turn-based combat and level progression

**What it does**:
- Randomly selects one of eight monsters with varying HP:
  - Weak: Wandering Skeleton (3 HP), Forest Goblin (5 HP)
  - Medium: Green Slime (10 HP), Ember Wolf (11 HP), Iron Golem (15 HP)
  - Strong: Giant Spider (18 HP), Lost Necromancer (20 HP)
  - Boss: Ancient Dragon (50 HP)
- Implements dice-based combat using ASCII art visualization
- Players roll virtual dice (1-6) each turn to deal damage
- Tracks monster HP reduction in real-time
- Awards one level upon monster defeat (maximum level 5)
- Provides combat feedback: damage dealt, remaining HP, victory messages

**Purpose**: Creates engaging combat encounters with visual elements and strategic progression, rewarding players with level advancement.

## Chapter 3: Loot the Mine (Mining Mini-game)
**Primary Function**: Resource gathering through grid-based exploration

**What it does**:
- Creates a 5x5 mining grid using dual matrix system:
  - Public matrix (visible to player)
  - Hidden matrix (actual coin locations)
- Players get 5 attempts to find coins by entering coordinates (0-4)
- Randomly places 5-10 coins in hidden positions at game start
- Provides immediate visual feedback:
  - Coin symbol (🪙) for successful finds
  - Wrong symbol (❌) for empty spots
  - Dash (-) for unexplored areas
- Awards 5-50 bits per coin found
- Tracks remaining attempts and total earnings

**Purpose**: Implements strategic resource gathering with limited attempts, encouraging thoughtful coordinate selection.

## Chapter 4: Show Inventory
**Primary Function**: Item management and display system

**What it does**:
- Maintains a dynamic array of player-owned items
- Handles both empty and populated inventory states
- Displays appropriate messages:
  - Empty: "Your inventory is currently empty"
  - Populated: Shows count and list of owned items
- Uses flexible array system that expands as players acquire items
- Provides clean, organized display of all possessions

**Purpose**: Gives players clear overview of their collected items and manages inventory growth throughout the game.

## Chapter 5: Buy Items (Shop System)
**Primary Function**: Economic transactions and item acquisition

**What it does**:
- Displays available items with prices:
  - Iron Dagger (30 bits)
  - Healing Potion (10 bits)
  - Ancient Key (50 bits)
  - Crossbow (40 bits)
  - Metal Shield (20 bits)
- Validates player purchases:
  - Checks sufficient funds
  - Processes successful transactions
  - Handles insufficient funds gracefully
- Implements dynamic array expansion for inventory
- Updates player's bit balance in real-time
- Provides purchase confirmation and error feedback

**Purpose**: Creates an economic system where players can strategically spend earned resources to enhance capabilities.

## Chapter 6: Show Attacks by Level
**Primary Function**: Spell progression and ability display

**What it does**:
- Organizes magical attacks into 5 tiered levels:
  - Level 1: Basic starter spell
  - Level 2: Elementary combat spells
  - Level 3: Intermediate area attacks
  - Level 4: Advanced specialized magic
  - Level 5: Ultimate powerful spells
- Displays all attacks available at current level and below
- Shows progression path and upcoming abilities
- Uses visual icons (emojis) for each spell type
- Provides clear level-based organization with headers


