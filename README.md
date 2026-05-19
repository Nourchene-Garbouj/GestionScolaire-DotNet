# 🎓 Gestion Scolaire — Application Desktop WPF .NET

> Application desktop de gestion scolaire développée avec WPF et Entity Framework Core, permettant la gestion des étudiants, des matières et des notes.

---

## 📋 Description

**Gestion Scolaire** est une application desktop .NET qui permet à un établissement scolaire de gérer efficacement ses étudiants, ses matières et ses notes. Elle respecte une architecture en 3 couches et utilise Entity Framework Core pour la communication avec la base de données SQL Server.

---

## ✨ Fonctionnalités

- 🔐 **Authentification** — Connexion sécurisée avec deux rôles (Admin / Professeur)
- 👨‍🎓 **Gestion des Étudiants** — Ajout, modification, suppression et affichage (CRUD complet)
- 📝 **Gestion des Notes** — Saisie des notes par étudiant et par matière
- 📚 **Gestion des Matières** — Ajout de matières avec coefficient
- 📊 **Tableau de Bord** — Statistiques : moyenne générale, taux de réussite, moyennes individuelles

---

## 🏗️ Architecture

L'application respecte une architecture en **3 couches** :

```
📁 DS .net
   📁 Models      ← Entités / Tables (Etudiant, Note, Matiere, Utilisateur)
   📁 Data        ← AppDbContext — Entity Framework Core
   📁 Business    ← Services — Logique métier (EtudiantService, NoteService...)
   📁 Views       ← Interfaces WPF (LoginWindow, CrudWindow, DashboardWindow...)
```

---

## 🗄️ Base de Données

4 tables reliées entre elles :

| Table | Champs |
|---|---|
| `Utilisateurs` | Id, Login, MotDePasse, Role |
| `Etudiants` | Id, Nom, Prenom, DateNaissance, Classe |
| `Matieres` | Id, Nom, Coefficient |
| `Notes` | Id, Valeur, Date, EtudiantId, MatiereId |

**Relations :**
- Un étudiant a plusieurs notes
- Une matière a plusieurs notes
- La table Notes fait le lien entre Etudiants et Matieres

---

## 🖥️ Interfaces

| Interface | Description |
|---|---|
| `LoginWindow` | Connexion avec gestion des rôles |
| `CrudWindow` | Gestion complète des étudiants |
| `NotesWindow` | Saisie et affichage des notes |
| `DashboardWindow` | Statistiques et tableau de bord |

---

## 🛠️ Technologies Utilisées

- **Langage** : C#
- **Framework UI** : WPF (Windows Presentation Foundation)
- **ORM** : Entity Framework Core
- **Base de données** : SQL Server Express
- **Requêtes** : LINQ
- **Version .NET** : .NET 10.0

---

## ⚙️ Installation

### Prérequis

- [Visual Studio 2022](https://visualstudio.microsoft.com/fr/downloads/) avec le module **Développement .NET Desktop**
- [SQL Server Express](https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)

### Étapes

**1. Cloner le repository**
```bash
git clone https://github.com/TON_USERNAME/GestionScolaire-DotNet.git
```

**2. Ouvrir le projet dans Visual Studio**
```
Ouvre le fichier DS .net.sln
```

**3. Configurer la connexion SQL Server**

Dans `Data/AppDbContext.cs`, modifie le nom du serveur :
```csharp
"Server=TON_SERVEUR\\SQLEXPRESS;Database=GestionScolaireDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

**4. Créer la base de données**

Dans la **Package Manager Console** :
```powershell
Add-Migration InitialCreate
Update-Database
```

**5. Lancer l'application**

Appuie sur `Ctrl + F5`

---

## 🔐 Identifiants par défaut

| Login | Mot de passe | Rôle |
|---|---|---|
| `admin` | `admin123` | Admin |
| `prof` | `prof123` | Professeur |

---

## 📁 Structure du Projet

```
DS .net/
├── Models/
│   ├── Utilisateur.cs
│   ├── Etudiant.cs
│   ├── Matiere.cs
│   └── Note.cs
├── Data/
│   └── AppDbContext.cs
├── Business/
│   ├── AuthService.cs
│   ├── EtudiantService.cs
│   ├── MatiereService.cs
│   └── NoteService.cs
├── Views/
│   ├── LoginWindow.xaml
│   ├── CrudWindow.xaml
│   ├── NotesWindow.xaml
│   └── DashboardWindow.xaml
└── App.xaml
```

---

## 👩‍💻 Auteur

Développé dans le cadre du projet **.NET — Développement Desktop**

**Nourchene Garbouj** — ESEN
