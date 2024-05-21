-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 25, 2021 at 04:20 PM
-- Server version: 10.1.31-MariaDB
-- PHP Version: 7.2.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `barcleshsoftdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `agence`
--

CREATE TABLE `agence` (
  `ID_AGENCE` int(11) NOT NULL,
  `NOM_AGENCE` varchar(50) NOT NULL,
  `CODE_AGENCE` varchar(60) NOT NULL,
  `FAX` varchar(17) NOT NULL,
  `EMAIL` varchar(60) NOT NULL,
  `TELEPHONE` varchar(17) NOT NULL,
  `VILLE` varchar(15) NOT NULL,
  `BOITE_POSTALE` varchar(10) NOT NULL,
  `PAYS` varchar(15) NOT NULL,
  `RUE` varchar(60) NOT NULL,
  `CATEGORIE_HOTEL` varchar(50) NOT NULL,
  `COULEUR_THEME` varchar(30) NOT NULL,
  `DATE_CREATION` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ETAGE` int(11) NOT NULL,
  `SOUS_SOLE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `agence`
--

INSERT INTO `agence` (`ID_AGENCE`, `NOM_AGENCE`, `CODE_AGENCE`, `FAX`, `EMAIL`, `TELEPHONE`, `VILLE`, `BOITE_POSTALE`, `PAYS`, `RUE`, `CATEGORIE_HOTEL`, `COULEUR_THEME`, `DATE_CREATION`, `ETAGE`, `SOUS_SOLE`) VALUES
(10, 'JOUVENCE YAOUNDE', '151130821175930', '545445', '564456', '4564', 'DOUALA', '545456', 'BANGLADESH', '54564', '', 'Color.FromArgb(205, 255, 255, ', '2021-08-13 17:59:30', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `article`
--

CREATE TABLE `article` (
  `ID_ARTICLE` int(11) NOT NULL,
  `CODE_ARTICLE` varchar(30) DEFAULT NULL,
  `REFERENCE` varchar(10) DEFAULT NULL,
  `CODE_BARRE` varchar(30) DEFAULT NULL,
  `DESIGNATION_FR` varchar(50) DEFAULT NULL,
  `DESIGNATION_EN` varchar(50) DEFAULT NULL,
  `DESCRIPTION` varchar(100) DEFAULT NULL,
  `CODE_GROUPE_ARTICLE` varchar(30) DEFAULT NULL,
  `CODE_FAMILLE` varchar(30) DEFAULT NULL,
  `CODE_SOUS_FAMILLE` varchar(30) DEFAULT NULL,
  `CODE_SOUS_SOUS_FAMILLE` varchar(30) DEFAULT NULL,
  `METHODE_SUIVI_STOCK` varchar(15) DEFAULT NULL,
  `TYPE_ARTICLE` varchar(30) DEFAULT NULL,
  `CONDITIONNEMENT` varchar(15) DEFAULT NULL,
  `SEUIL_PRIX_VENTE_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_ACHAT_HT` decimal(17,2) DEFAULT NULL,
  `COUT_U_MOYEN_PONDERE` decimal(17,2) DEFAULT NULL,
  `PRIX_ACHAT_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE1_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE1_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE2_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE2_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE3_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE3_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE4_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE4_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE5_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE5_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE6_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE6_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE7_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE7_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE8_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE8_TTC` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE9_HT` decimal(17,2) DEFAULT NULL,
  `PRIX_VENTE9_TTC` decimal(17,2) DEFAULT NULL,
  `POURCENTAGE_REMISE` decimal(17,2) DEFAULT NULL,
  `TAUX_EXONERATION_TVA` decimal(17,2) DEFAULT NULL,
  `SEUIL_REAPPROVISIONNEMENT` decimal(17,2) DEFAULT NULL,
  `NUMERO_SERIE` varchar(10) DEFAULT NULL,
  `ARTICLE_COMPOSE` varchar(1) DEFAULT NULL,
  `ARTICLE_LIE` varchar(1) DEFAULT NULL,
  `ARTICLE_RECONDITIONNABLE` varchar(1) DEFAULT NULL,
  `APPARAIT_SUR_FICHE_CLIENT` varchar(1) DEFAULT NULL,
  `ARTICLE_PERISSABLE` varchar(1) DEFAULT NULL,
  `ARTICLE_GERE_PAR_LOT` varchar(1) DEFAULT NULL,
  `DATE_DEBUT_PROMOTION` date DEFAULT NULL,
  `POURCENTAGE_REMISE_PROMOTION` decimal(17,2) DEFAULT NULL,
  `DATE_FIN_PROMOTION` date DEFAULT NULL,
  `CHEMIN_PHOTO` varchar(255) DEFAULT NULL,
  `DATE_CREATION` date DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `DATE_MODIFICATION` date DEFAULT NULL,
  `CODE_UTILISATEUR_MODIF` varchar(30) DEFAULT NULL,
  `ARTICLE_A_REMISE` varchar(1) DEFAULT NULL,
  `CODE_CLE` varchar(30) DEFAULT NULL,
  `DELEGUE` varchar(1) DEFAULT NULL,
  `SEUIL_PRIX_VENTE_TTC` decimal(17,2) DEFAULT NULL,
  `TX_LIMIT` decimal(17,2) DEFAULT NULL,
  `DAILY_LIMIT` decimal(17,2) DEFAULT NULL,
  `TAUX_TVA` decimal(17,2) DEFAULT '0.00',
  `SPECIALITE_ARTICLE` varchar(1) DEFAULT NULL,
  `ARTICLE_MULTIPRIX` varchar(1) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `article`
--

INSERT INTO `article` (`ID_ARTICLE`, `CODE_ARTICLE`, `REFERENCE`, `CODE_BARRE`, `DESIGNATION_FR`, `DESIGNATION_EN`, `DESCRIPTION`, `CODE_GROUPE_ARTICLE`, `CODE_FAMILLE`, `CODE_SOUS_FAMILLE`, `CODE_SOUS_SOUS_FAMILLE`, `METHODE_SUIVI_STOCK`, `TYPE_ARTICLE`, `CONDITIONNEMENT`, `SEUIL_PRIX_VENTE_HT`, `PRIX_ACHAT_HT`, `COUT_U_MOYEN_PONDERE`, `PRIX_ACHAT_TTC`, `PRIX_VENTE_HT`, `PRIX_VENTE_TTC`, `PRIX_VENTE1_HT`, `PRIX_VENTE1_TTC`, `PRIX_VENTE2_HT`, `PRIX_VENTE2_TTC`, `PRIX_VENTE3_HT`, `PRIX_VENTE3_TTC`, `PRIX_VENTE4_HT`, `PRIX_VENTE4_TTC`, `PRIX_VENTE5_HT`, `PRIX_VENTE5_TTC`, `PRIX_VENTE6_HT`, `PRIX_VENTE6_TTC`, `PRIX_VENTE7_HT`, `PRIX_VENTE7_TTC`, `PRIX_VENTE8_HT`, `PRIX_VENTE8_TTC`, `PRIX_VENTE9_HT`, `PRIX_VENTE9_TTC`, `POURCENTAGE_REMISE`, `TAUX_EXONERATION_TVA`, `SEUIL_REAPPROVISIONNEMENT`, `NUMERO_SERIE`, `ARTICLE_COMPOSE`, `ARTICLE_LIE`, `ARTICLE_RECONDITIONNABLE`, `APPARAIT_SUR_FICHE_CLIENT`, `ARTICLE_PERISSABLE`, `ARTICLE_GERE_PAR_LOT`, `DATE_DEBUT_PROMOTION`, `POURCENTAGE_REMISE_PROMOTION`, `DATE_FIN_PROMOTION`, `CHEMIN_PHOTO`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `ARTICLE_A_REMISE`, `CODE_CLE`, `DELEGUE`, `SEUIL_PRIX_VENTE_TTC`, `TX_LIMIT`, `DAILY_LIMIT`, `TAUX_TVA`, `SPECIALITE_ARTICLE`, `ARTICLE_MULTIPRIX`, `CODE_AGENCE`) VALUES
(12, '124210821103653', '', '', 'TANGUI', '', '', '', '', 'BOISSON NON ALCOLISEE', '', '', 'BAR', '', '0.00', '450.00', '0.00', '0.00', '750.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', '', '', '', '', '', '', '2021-08-20', '0.00', '2021-08-20', '', '2021-08-20', '', '2021-08-20', '', '', '', '', '0.00', '0.00', '0.00', '0.00', '', '', '151130821175930'),
(13, '293210821104839', '', '', 'POISSON', '', '', '', '', 'BOISSON NON ALCOLISEE', '', '', 'RESTAURANT', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', '', '', '', '', '', '', '2021-08-20', '0.00', '2021-08-20', '', '2021-08-20', '', '2021-08-20', '', '', '', '', '0.00', '0.00', '0.00', '0.00', '', '', '151130821175930'),
(14, '337240821163838', '', '', 'LOCATION HEBERGEMENT', '', '', '', '', 'HEBERGEMENT', '', '', 'SERVICES', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', '', '', '', '', '', '', '2021-08-25', '0.00', '2021-08-25', '', '2021-08-25', '', '2021-08-25', '', '', '', '', '0.00', '0.00', '0.00', '0.00', '', '', '151130821175930');

-- --------------------------------------------------------

--
-- Table structure for table `caisse`
--

CREATE TABLE `caisse` (
  `ID_CAISSE` int(11) NOT NULL,
  `CODE_CAISSE` varchar(50) DEFAULT NULL,
  `LIBELLE_CAISSE` varchar(50) DEFAULT NULL,
  `CODE_UTILISATEUR` varchar(30) DEFAULT NULL,
  `NUM_COMPTE` varchar(10) DEFAULT NULL,
  `ETAT_CAISSE` varchar(15) DEFAULT NULL,
  `SOLDE_CAISSE` double(17,2) DEFAULT '0.00',
  `DATE_CREATION` date DEFAULT NULL,
  `DATE_COMPTABLE` date DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `DATE_MODIFICATION` date DEFAULT NULL,
  `CODE_UTILISATEUR_MODIF` varchar(30) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `TYPE_CAISSE` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `caisse`
--

INSERT INTO `caisse` (`ID_CAISSE`, `CODE_CAISSE`, `LIBELLE_CAISSE`, `CODE_UTILISATEUR`, `NUM_COMPTE`, `ETAT_CAISSE`, `SOLDE_CAISSE`, `DATE_CREATION`, `DATE_COMPTABLE`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`, `TYPE_CAISSE`) VALUES
(3, 'CAISS', 'SEULE CAISSIERE', 'reception', '', 'Fermée', 0.00, '2021-08-26', '2021-08-26', 'hello', '2021-08-26', 'dfdsfd', '151130821175930', 'Compte Caisse');

-- --------------------------------------------------------

--
-- Table structure for table `categorie_chambre`
--

CREATE TABLE `categorie_chambre` (
  `ID_CATEGORIE_CHAMBRE` int(11) NOT NULL,
  `CODE_CATEGORIE_CHAMBRE` varchar(20) NOT NULL,
  `NOM_CATEGORIE_CHAMBRE` varchar(100) NOT NULL,
  `SYMBOLE` varchar(50) DEFAULT NULL,
  `NOMBRE_LIT_UNE_PLACE` int(50) NOT NULL,
  `NOMBRE_LIT_DEUX_PLACES` int(50) NOT NULL,
  `CODE_AGENCE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `categorie_chambre`
--

INSERT INTO `categorie_chambre` (`ID_CATEGORIE_CHAMBRE`, `CODE_CATEGORIE_CHAMBRE`, `NOM_CATEGORIE_CHAMBRE`, `SYMBOLE`, `NOMBRE_LIT_UNE_PLACE`, `NOMBRE_LIT_DEUX_PLACES`, `CODE_AGENCE`) VALUES
(157, 'CC1221125072103548', 'SINGLE', 'SL', 2, 1, 'AG228362507211543'),
(158, 'CC222225072103555', 'TWINS', 'TW', 1, 1, 'AG228362507211543'),
(159, 'CC349732507210361', 'DOUBLE', 'DD', 0, 3, 'AG228362507211543'),
(160, 'CC440722507210365', 'TRIPLE', 'TR', 0, 1, 'AG228362507211543'),
(161, 'CC53040821124056', 'GRAND CONFRT', 'GC', 0, 1, 'AG17040821124016'),
(162, 'CC61204082112418', 'VIP', 'VIP', 0, 1, 'AG17040821124016');

-- --------------------------------------------------------

--
-- Table structure for table `categorie_client`
--

CREATE TABLE `categorie_client` (
  `ID_TYPE_CLIENT` int(11) NOT NULL,
  `CODE_TYPE_CLIENT` varchar(30) NOT NULL,
  `LIBELLE` varchar(50) NOT NULL,
  `PAIE_TAXE_SEJOUR` varchar(5) NOT NULL DEFAULT 'NON',
  `DATE_CREATION` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `TAUX_EXONERATION_TVA` double NOT NULL,
  `POURCENTAGE_REMISE` int(5) NOT NULL,
  `POURCENTAGE_RISTOURNE` int(5) NOT NULL,
  `CODE_UTILISATEUR` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `categorie_client`
--

INSERT INTO `categorie_client` (`ID_TYPE_CLIENT`, `CODE_TYPE_CLIENT`, `LIBELLE`, `PAIE_TAXE_SEJOUR`, `DATE_CREATION`, `TAUX_EXONERATION_TVA`, `POURCENTAGE_REMISE`, `POURCENTAGE_RISTOURNE`, `CODE_UTILISATEUR`) VALUES
(1, 'CAC149010821172730', 'NORMAL', '0', '2021-08-01 00:00:00', 0, 0, 0, ''),
(2, 'CAC235010821172738', 'ENTREPRISE', '0', '2021-08-03 00:00:00', 0, 0, 0, ''),
(3, 'CAC31010821172749', 'INDIVIDUEL', '0', '2021-08-01 00:00:00', 0, 0, 0, '');

-- --------------------------------------------------------

--
-- Table structure for table `category_hotel_taxe_sejour_collectee`
--

CREATE TABLE `category_hotel_taxe_sejour_collectee` (
  `ID_CATEGORIE` int(11) NOT NULL,
  `CODE_CATEGORIE_HOTEL` varchar(100) NOT NULL,
  `LIBELLE` varchar(100) NOT NULL,
  `MONTANT_TAXE` double NOT NULL,
  `DATE_CREATION` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CODE_UTILISATEUR` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `chambre`
--

CREATE TABLE `chambre` (
  `ID_CHAMBRE` int(11) NOT NULL,
  `CODE_CHAMBRE` varchar(30) NOT NULL,
  `CODE_TYPE_CHAMBRE` varchar(100) NOT NULL,
  `CODE_CATEGORY_CHAMBRE` varchar(100) NOT NULL,
  `LIBELLE_CHAMBRE` varchar(50) NOT NULL,
  `ETAT_CHAMBRE` int(5) NOT NULL,
  `ETAT_CHAMBRE_NOTE` varchar(20) NOT NULL DEFAULT 'Libre propre',
  `LOCALISATION` varchar(50) NOT NULL,
  `NUM_COMPTE` varchar(30) NOT NULL,
  `PRIX` double NOT NULL,
  `FICITIF` int(1) NOT NULL,
  `LOCK_NO` varchar(100) NOT NULL,
  `GUEST_DAI` varchar(30) NOT NULL,
  `DATE_CREATION` date NOT NULL,
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre',
  `CODE_AGENCE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `chambre`
--

INSERT INTO `chambre` (`ID_CHAMBRE`, `CODE_CHAMBRE`, `CODE_TYPE_CHAMBRE`, `CODE_CATEGORY_CHAMBRE`, `LIBELLE_CHAMBRE`, `ETAT_CHAMBRE`, `ETAT_CHAMBRE_NOTE`, `LOCALISATION`, `NUM_COMPTE`, `PRIX`, `FICITIF`, `LOCK_NO`, `GUEST_DAI`, `DATE_CREATION`, `TYPE`, `CODE_AGENCE`) VALUES
(4, '102', 'SG', 'Electricité', 'CHAMBRE POUR PERSONNE VIP', 0, 'Occupée sale', 'DEVANT ESCALIER NORD', '', 55000, 0, '', '', '2021-08-13', 'chambre', '151130821175930'),
(5, '103', 'GC', 'Electricité', 'AGREABLE POUR UN SEJOUR SINGLE', 0, 'Occupée sale', 'DEVANT ASCENCEUR', '', 35000, 0, 'KJSKFDJFKJD', 'LKFJSLKJD', '2021-08-13', 'chambre', '151130821175930'),
(6, '104', 'SG', 'Electricité', 'FANTASTIQUE', 0, 'Occupée sale', 'DEVANT ', '', 55000, 0, '', '', '2021-08-20', 'chambre', '151130821175930'),
(7, '101', 'SG', 'Electricité', '-', 0, 'Occupée sale', 'AVANT', '', 55000, 0, '-', '-', '2021-08-22', 'chambre', '151130821175930'),
(8, '106', 'GC', 'Electricité', '--', 0, 'Occupée sale', '-', '', 35000, 0, '-', '-', '2021-08-22', 'chambre', '151130821175930'),
(9, '105', 'SG', 'Plomberie', 'HGJHJ', 0, 'Occupée propre', 'JJH', '', 55000, 0, 'GHJGHJ', 'GHJGJ', '2021-08-22', 'chambre', '151130821175930'),
(10, '107', 'GC', 'Aucun problème', 'GJHJ', 0, 'Occupée sale', 'GHJHJ', '', 35000, 0, 'HGJHJ', 'GJHGJ', '2021-08-22', 'chambre', '151130821175930'),
(11, '108', 'SG', 'Electricité', 'FG', 0, 'Occupée sale', 'DGDFG', '', 55000, 0, ';:;,:', ',;:;', '2021-08-22', 'chambre', '151130821175930'),
(12, '109', 'SG', 'Electricité', 'HKHJK', 0, 'Occupée sale', 'HKHJK', '', 55000, 0, 'JHKK', 'HJKJHK', '2021-08-22', 'chambre', '151130821175930');

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `ID_CLIENT` int(11) NOT NULL,
  `CODE_CLIENT` varchar(30) NOT NULL,
  `NOM_CLIENT` varchar(150) NOT NULL,
  `NOM_PRENOM` varchar(100) NOT NULL,
  `NOM_JEUNE_FILLE` varchar(50) NOT NULL,
  `PRENOMS` varchar(30) NOT NULL,
  `ADRESSE` varchar(50) NOT NULL,
  `TELEPHONE` varchar(30) NOT NULL,
  `FAX` varchar(30) NOT NULL,
  `EMAIL` varchar(50) NOT NULL,
  `NUM_COMPTE` varchar(30) NOT NULL,
  `NATIONALITE` varchar(50) NOT NULL,
  `DATE_DE_NAISSANCE` date NOT NULL,
  `LIEU_DE_NAISSANCE` varchar(30) NOT NULL,
  `PAYS_RESIDENCE` varchar(50) NOT NULL,
  `VILLE_DE_RESIDENCE` varchar(30) NOT NULL,
  `PROFESSION` varchar(50) NOT NULL,
  `CNI` varchar(50) NOT NULL,
  `CODE_MODE_PAIEMENT` varchar(30) DEFAULT NULL,
  `NUM_COMPTE_COLLECTIF` varchar(10) NOT NULL,
  `DATE_CREATION` date NOT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) NOT NULL,
  `DATE_MODIFICATION` date NOT NULL,
  `RECEVOIR_EMAIL` int(5) NOT NULL,
  `RECEVOIR_SMS` int(5) NOT NULL,
  `TYPE_CLIENT` varchar(50) DEFAULT NULL,
  `SITE_INTERNET` varchar(100) NOT NULL,
  `CODE_AGENCE` varchar(30) NOT NULL,
  `CODE_UTILISATEUR_MODIF` varchar(50) NOT NULL,
  `CODE_ENTREPRISE` varchar(30) NOT NULL,
  `MODE_TRANSPORT` varchar(30) NOT NULL,
  `NUM_VEHICULE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`ID_CLIENT`, `CODE_CLIENT`, `NOM_CLIENT`, `NOM_PRENOM`, `NOM_JEUNE_FILLE`, `PRENOMS`, `ADRESSE`, `TELEPHONE`, `FAX`, `EMAIL`, `NUM_COMPTE`, `NATIONALITE`, `DATE_DE_NAISSANCE`, `LIEU_DE_NAISSANCE`, `PAYS_RESIDENCE`, `VILLE_DE_RESIDENCE`, `PROFESSION`, `CNI`, `CODE_MODE_PAIEMENT`, `NUM_COMPTE_COLLECTIF`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `TYPE_CLIENT`, `SITE_INTERNET`, `CODE_AGENCE`, `CODE_UTILISATEUR_MODIF`, `CODE_ENTREPRISE`, `MODE_TRANSPORT`, `NUM_VEHICULE`) VALUES
(8, '1351808216575', 'KAMDEM KAMDEM', 'KAMDEM KAMDEM ', '', '', '', ' 693534844', '', '', '', '', '2021-06-10', '', 'AFGHANISTAN', 'YAOUNDE', '', '', NULL, '', '2021-08-18', '', '2021-08-25', 0, 0, 'NORMAL', '', '151130821175930', '', '2418082173956', '', ''),
(9, '2418082173956', 'BARCLES DIGITAL TECHNOLOGIES', 'BARCLES DIGITAL TECHNOLOGIES ', '', '', '', '   -   -', '', '', '', '', '2021-06-10', '', 'AFGHANISTAN', 'YAOUNDE', '', '', NULL, '', '2021-08-18', '', '2021-08-18', 0, 0, 'ENTREPRISE', '', '151130821175930', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `cloture`
--

CREATE TABLE `cloture` (
  `ID_CLOTURE` int(11) NOT NULL,
  `CODE_CLOTURE` varchar(30) NOT NULL,
  `DATE_DE_TRAVAIL` date NOT NULL,
  `CLOTURE_A` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cloture`
--

INSERT INTO `cloture` (`ID_CLOTURE`, `CODE_CLOTURE`, `DATE_DE_TRAVAIL`, `CLOTURE_A`) VALUES
(1, '1223082173924', '2021-08-23', '2021-08-23 05:39:24'),
(2, '2123082174118', '2021-08-24', '2021-08-23 05:41:18'),
(3, '38523082181136', '2021-08-25', '2021-08-23 06:11:36'),
(4, '423240821175013', '2021-08-26', '2021-08-24 15:50:13');

-- --------------------------------------------------------

--
-- Table structure for table `compte`
--

CREATE TABLE `compte` (
  `ID_COMPTE` int(11) NOT NULL,
  `INTITULE` varchar(50) NOT NULL,
  `NUMERO_COMPTE` varchar(30) NOT NULL,
  `CODE_CLIENT` varchar(30) NOT NULL,
  `TOTAL_DEBIT` double NOT NULL,
  `TOTAL_CREDIT` double NOT NULL,
  `SOLDE_COMPTE` double NOT NULL,
  `DATE_CREATION` date NOT NULL,
  `TYPE_DE_COMPTE` varchar(50) NOT NULL,
  `SENS_DU_SOLDE` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `electronic_lock_zeno`
--

CREATE TABLE `electronic_lock_zeno` (
  `CODE_CLIENT` varchar(20) DEFAULT NULL,
  `CODE_CHAMBRE` varchar(30) DEFAULT NULL,
  `CODE_RESERVATION` varchar(30) DEFAULT NULL,
  `NOM_CLIENT` varchar(50) DEFAULT NULL,
  `CODE_TYPE_CHAMBRE` varchar(30) DEFAULT NULL,
  `PRIX_CHAMBRE` decimal(17,2) DEFAULT NULL,
  `CARD_ID` varchar(25) DEFAULT NULL,
  `CARD_DATA` varchar(255) DEFAULT NULL,
  `DATE_ARRIVEE` datetime(6) NOT NULL,
  `DATE_DEPART` datetime(6) NOT NULL,
  `DATE_CREATION` datetime(6) DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `CODE_UTILISATEUR_MODIF` varchar(30) DEFAULT NULL,
  `DATE_MODIFICATION` datetime(6) DEFAULT NULL,
  `NOM_ORDINATEUR` varchar(255) DEFAULT NULL,
  `ETAT_CHAMBRE_SERRURE` varchar(1) DEFAULT NULL,
  `TYPE_RECORD` varchar(50) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `entreprise`
--

CREATE TABLE `entreprise` (
  `ID_ENTREPRISE` int(11) NOT NULL,
  `CODE_ENTREPRISE` varchar(30) NOT NULL,
  `NOM_ENTREPRISE` varchar(100) NOT NULL,
  `EMAIL_ENTREPRISE` varchar(100) NOT NULL,
  `TELEPHONE_ENTREPRISE` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `facture`
--

CREATE TABLE `facture` (
  `ID_FACTURE` int(20) NOT NULL,
  `CODE_FACTURE` varchar(30) DEFAULT NULL,
  `CODE_RESERVATION` varchar(30) DEFAULT NULL,
  `CODE_COMMANDE` varchar(30) DEFAULT NULL,
  `NUMERO_TABLE` varchar(15) DEFAULT NULL,
  `CODE_MODE_PAIEMENT` varchar(30) DEFAULT NULL,
  `NUM_MOUVEMENT` varchar(10) DEFAULT NULL,
  `DATE_FACTURE` date DEFAULT NULL,
  `CODE_CLIENT` varchar(30) DEFAULT NULL,
  `CODE_COMMERCIAL` varchar(2) DEFAULT NULL,
  `MONTANT_HT` decimal(17,2) DEFAULT NULL,
  `TAXE` decimal(17,2) DEFAULT NULL,
  `MONTANT_TTC` decimal(17,2) DEFAULT NULL,
  `AVANCE` decimal(17,2) DEFAULT NULL,
  `RESTE_A_PAYER` decimal(17,2) DEFAULT NULL,
  `DATE_PAIEMENT` date DEFAULT NULL,
  `ETAT_FACTURE` int(11) DEFAULT '0',
  `LIBELLE_FACTURE` varchar(100) DEFAULT NULL,
  `MONTANT_TRANSPORT` decimal(17,2) DEFAULT NULL,
  `MONTANT_REMISE` decimal(17,2) DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `CODE_UTILISATEUR_ANNULE` varchar(30) DEFAULT NULL,
  `CODE_UTILISATEUR_VALIDE` varchar(30) DEFAULT NULL,
  `NOM_CLIENT_FACTURE` varchar(50) DEFAULT NULL,
  `MONTANT_AVANCE` decimal(17,2) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `TYPE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facture`
--

INSERT INTO `facture` (`ID_FACTURE`, `CODE_FACTURE`, `CODE_RESERVATION`, `CODE_COMMANDE`, `NUMERO_TABLE`, `CODE_MODE_PAIEMENT`, `NUM_MOUVEMENT`, `DATE_FACTURE`, `CODE_CLIENT`, `CODE_COMMERCIAL`, `MONTANT_HT`, `TAXE`, `MONTANT_TTC`, `AVANCE`, `RESTE_A_PAYER`, `DATE_PAIEMENT`, `ETAT_FACTURE`, `LIBELLE_FACTURE`, `MONTANT_TRANSPORT`, `MONTANT_REMISE`, `CODE_UTILISATEUR_CREA`, `CODE_UTILISATEUR_ANNULE`, `CODE_UTILISATEUR_VALIDE`, `NOM_CLIENT_FACTURE`, `MONTANT_AVANCE`, `CODE_AGENCE`, `TYPE`) VALUES
(2, '13823082181134', '1112308218936', '', '', '', '', '2021-08-23', '1351808216575', '', '105000.00', '0.00', '105000.00', '0.00', '0.00', '0001-01-01', 0, 'Location logement (107)', '0.00', '0.00', '', '', '', '', '0.00', '151130821175930', 'chambre'),
(3, '2223082191149', '1112308218936', '', '', '', '', '2021-08-23', '1351808216575', '', '750.00', '0.00', '750.00', '0.00', '0.00', '0001-01-01', 0, 'FCATURATION BAR', '0.00', '0.00', '', '', '', 'KAMDEM KAMDEM ', '0.00', '151130821175930', 'chambre'),
(4, '3123082194351', '1112308218936', '', '', '', '', '2021-08-23', '1351808216575', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0001-01-01', 0, 'FCATURATION RESTAURANT', '0.00', '0.00', '', '', '', 'KAMDEM KAMDEM ', '0.00', '151130821175930', 'chambre'),
(5, '49230821151454', 'Client comptoire', '', '', '', '', '2021-08-23', '', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0001-01-01', 0, 'Facturation BAR', '0.00', '0.00', '', '', '', NULL, '0.00', '151130821175930', 'chambre'),
(6, '594230821152754', 'Client comptoire', '', '', '', '', '2021-08-23', '', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0001-01-01', 0, 'Facturation RESTAURANT', '0.00', '0.00', '', '', '', NULL, '0.00', '151130821175930', 'chambre'),
(7, '668230821181050', 'Client comptoire', '', '', '', '', '2021-08-23', '', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0001-01-01', 0, 'FACTURATION RESTAURANT', '0.00', '0.00', '', '', '', NULL, '0.00', '151130821175930', 'chambre'),
(8, '712240821163845', 'Client comptoire', '', '', '', '', '2021-08-24', '', '', '0.00', '0.00', '0.00', '0.00', '0.00', '0001-01-01', 0, 'FACTURATION BAR / RESTAURANT', '0.00', '0.00', '', '', '', NULL, '0.00', '151130821175930', 'chambre'),
(9, '8224082117507', '14240821174919', '', '', '', '', '2021-08-24', '1351808216575', '', '15000.00', '0.00', '15000.00', '0.00', '0.00', '0001-01-01', 0, 'Location logement (102)', '0.00', '0.00', '', '', '', '', '0.00', '151130821175930', 'chambre'),
(10, '91824082117509', '1112308218936', '', '', '', '', '2021-08-24', '1351808216575', '', '35000.00', '0.00', '35000.00', '0.00', '0.00', '0001-01-01', 0, 'Location logement (107)', '0.00', '0.00', '', '', '', '', '0.00', '151130821175930', 'chambre');

-- --------------------------------------------------------

--
-- Table structure for table `famille`
--

CREATE TABLE `famille` (
  `ID_FAMILLE` int(11) NOT NULL,
  `CODE_FAMILLE` varchar(30) DEFAULT NULL,
  `LIBELLE_FAMILLE` varchar(50) DEFAULT NULL,
  `NIVEAU_HIERARCHIQUE` varchar(100) DEFAULT NULL,
  `CODE_FAMILLE_PARENT` varchar(30) DEFAULT NULL,
  `NUM_COMPTE_MARCHANDISE` varchar(30) DEFAULT NULL,
  `NUM_COMPTE_VENTE` varchar(30) DEFAULT NULL,
  `METHODE_SUIVI_STOCK` varchar(15) DEFAULT NULL,
  `POURCENTAGE_REMISE` decimal(17,2) DEFAULT NULL,
  `TAUX_TVA` decimal(17,2) DEFAULT NULL,
  `DATE_CREATION` datetime DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `DATE_MODIFICATION` datetime DEFAULT NULL,
  `CODE_UTILISATEUR_MODIF` varchar(30) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `famille`
--

INSERT INTO `famille` (`ID_FAMILLE`, `CODE_FAMILLE`, `LIBELLE_FAMILLE`, `NIVEAU_HIERARCHIQUE`, `CODE_FAMILLE_PARENT`, `NUM_COMPTE_MARCHANDISE`, `NUM_COMPTE_VENTE`, `METHODE_SUIVI_STOCK`, `POURCENTAGE_REMISE`, `TAUX_TVA`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`) VALUES
(1, 'FAR125140821114439', 'BAR', 'PAS BON POUS LA SANTE', '', '', '', 'Suivi simple', '0.00', '19.50', '2021-08-14 00:00:00', 'Suivi simple', '0000-00-00 00:00:00', '2021-08-20 00:00:00', ''),
(2, 'FAR24140821114836', 'RESTAURANT', '', '', '', '', 'Suivi simple', '0.00', '0.00', '2021-08-14 00:00:00', '', '2021-08-14 00:00:00', '', '151130821175930'),
(3, '32616082110417', 'KIOSQUE A JOURNAUX', '', '', '', '', 'Suivi simple', '0.00', '19.50', '2021-09-23 00:00:00', 'Suivi simple', '0000-00-00 00:00:00', '2021-09-23 00:00:00', ''),
(5, '4632108219494', 'SERVICES', '', '', '', '', 'Suivi simple', '0.00', '0.00', '2021-08-20 00:00:00', 'Suivi simple', '0000-00-00 00:00:00', '2021-08-20 00:00:00', ''),
(6, '5821082194914', 'SALON DE BEAUTE', '', '', '', '', NULL, '0.00', '0.00', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '151130821175930'),
(7, '62821082194923', 'BOUTIQUE', '', '', '', '', NULL, '0.00', '0.00', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '151130821175930'),
(8, '73121082194933', 'BUSINESS CENTER', '', '', '', '', NULL, '0.00', '0.00', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '151130821175930'),
(9, '83121082194942', 'LOISIRS', '', '', '', '', NULL, '0.00', '0.00', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '151130821175930'),
(10, '9221082194951', 'SPORTS', '', '', '', '', NULL, '0.00', '0.00', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '151130821175930'),
(11, '102721082194957', 'AUTRES', '', '', '', '', NULL, '0.00', '0.00', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '151130821175930');

-- --------------------------------------------------------

--
-- Table structure for table `forfait_salle`
--

CREATE TABLE `forfait_salle` (
  `ID_FORFAIT_SALE` int(11) NOT NULL,
  `CODE_RESERVATION` varchar(30) NOT NULL,
  `NBRE__CAFE` int(11) NOT NULL,
  `PU_CAFE` double NOT NULL,
  `NBRE_DEJEUNER` int(11) NOT NULL,
  `PU_DEJEUNER` double NOT NULL,
  `NBRE_DINER` int(11) NOT NULL,
  `PU_DINER` double NOT NULL,
  `NBRE_TRAITEUR` int(11) NOT NULL,
  `PU_TRAITEUR` double NOT NULL,
  `DECORATION` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `forfait_salle`
--

INSERT INTO `forfait_salle` (`ID_FORFAIT_SALE`, `CODE_RESERVATION`, `NBRE__CAFE`, `PU_CAFE`, `NBRE_DEJEUNER`, `PU_DEJEUNER`, `NBRE_DINER`, `PU_DINER`, `NBRE_TRAITEUR`, `PU_TRAITEUR`, `DECORATION`) VALUES
(1, '1114082184537', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(2, '13115082163451', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(3, '170150821104625', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(4, '18150821131924', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(5, '111150821132346', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(6, '138150821151518', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(7, '139150821161213', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(8, '171150821161433', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(9, '12415082116440', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(10, '17015082117221', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(11, '169150821171251', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(12, '1716082124015', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(13, '1016082131818', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(14, '1401608213380', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(15, '12216082134319', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(16, '16416082134648', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(17, '15116082134922', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(18, '17816082164027', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(19, '11016082164212', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(20, '171608217954', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(21, '1316082172323', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(22, '17416082173440', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(23, '124180821112335', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(24, '30180821114342', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(25, '35180821131343', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(26, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(27, '512180821144343', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(28, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(29, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(30, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(31, '133180821145135', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(32, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(33, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(34, '1518082115437', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(35, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(36, '314180821151029', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(37, '342180821151256', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(38, '111180821151858', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(39, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(40, '13180821152716', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(41, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(42, '547180821153841', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(43, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(44, '340180821154818', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(45, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(46, '757180821154854', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(47, '91118082115490', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(48, '928180821155758', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(49, '', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(50, '1018082116039', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(51, '3318082116046', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(52, '5618082116054', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(53, '31219082175339', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(54, '1381908218233', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(55, '17219082185130', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(56, '18190821124039', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(57, '1819082113437', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(58, '120190821134134', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(59, '12319082113434', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(60, '1219082114330', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(61, '110190821144317', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(62, '143190821144524', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(63, '136190821152157', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(64, '1102008213213', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(65, '31520082132333', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(66, '5220082153751', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(67, '15520082154659', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(68, '315200821629', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(69, '702008216553', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(70, '9392008216656', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(71, '111120082161049', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(72, '13120082174213', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(73, '13220082175219', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(74, '1320082175952', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(75, '1232008218154', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(76, '11320082120110', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(77, '11921082111512', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(78, '10210821125421', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(79, '13121082113044', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(80, '14240821174919', 0, 0, 0, 0, 0, 0, 0, 0, 0),
(81, '15325082116115', 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `groupe_article`
--

CREATE TABLE `groupe_article` (
  `ID_GROUPE_ARTICLE` int(11) NOT NULL,
  `CODE_GROUPE_ARTICLE` varchar(30) DEFAULT NULL,
  `LIBELLE_GROUPE_ARTICLE` varchar(50) DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `DATE_CREATION` datetime DEFAULT NULL,
  `CODE_UTILISATEUR_MODIF` varchar(30) DEFAULT NULL,
  `DATE_MODIFICATION` datetime DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `ligne_facture`
--

CREATE TABLE `ligne_facture` (
  `ID_LIGNE_FACTURE` int(11) NOT NULL,
  `CODE_FACTURE` varchar(30) DEFAULT NULL,
  `CODE_RESERVATION` varchar(30) DEFAULT NULL,
  `CODE_MOUVEMENT` varchar(30) DEFAULT NULL,
  `CODE_CHAMBRE` varchar(30) DEFAULT NULL,
  `CODE_MODE_PAIEMENT` varchar(30) DEFAULT NULL,
  `NUMERO_PIECE` varchar(30) DEFAULT NULL,
  `CODE_ARTICLE` varchar(30) DEFAULT NULL,
  `CODE_LOT` varchar(30) DEFAULT NULL,
  `MONTANT_HT` decimal(17,2) DEFAULT NULL,
  `TAXE` decimal(17,2) DEFAULT NULL,
  `QUANTITE` decimal(17,2) DEFAULT '1.00',
  `PRIX_UNITAIRE_TTC` decimal(17,2) DEFAULT NULL,
  `MONTANT_TTC` decimal(17,2) DEFAULT NULL,
  `DATE_FACTURE` datetime DEFAULT NULL,
  `HEURE_FACTURE` datetime DEFAULT NULL,
  `ETAT_FACTURE` int(11) DEFAULT '0',
  `DATE_OCCUPATION` datetime DEFAULT NULL,
  `HEURE_OCCUPATION` datetime DEFAULT NULL,
  `LIBELLE_FACTURE` varchar(100) DEFAULT NULL,
  `TYPE_LIGNE_FACTURE` varchar(1) DEFAULT NULL,
  `NUMERO_SERIE` varchar(20) DEFAULT NULL,
  `NUMERO_ORDRE` decimal(17,2) DEFAULT NULL,
  `DESCRIPTION` varchar(255) DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `MONTANT_REMISE` decimal(17,2) DEFAULT NULL,
  `MONTANT_TAXE` decimal(17,2) DEFAULT NULL,
  `NUMERO_SERIE_DEBUT` varchar(20) DEFAULT NULL,
  `NUMERO_SERIE_FIN` varchar(20) DEFAULT NULL,
  `CODE_MAGASIN` varchar(30) DEFAULT NULL,
  `FUSIONNEE` varchar(1) DEFAULT NULL,
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ligne_facture`
--

INSERT INTO `ligne_facture` (`ID_LIGNE_FACTURE`, `CODE_FACTURE`, `CODE_RESERVATION`, `CODE_MOUVEMENT`, `CODE_CHAMBRE`, `CODE_MODE_PAIEMENT`, `NUMERO_PIECE`, `CODE_ARTICLE`, `CODE_LOT`, `MONTANT_HT`, `TAXE`, `QUANTITE`, `PRIX_UNITAIRE_TTC`, `MONTANT_TTC`, `DATE_FACTURE`, `HEURE_FACTURE`, `ETAT_FACTURE`, `DATE_OCCUPATION`, `HEURE_OCCUPATION`, `LIBELLE_FACTURE`, `TYPE_LIGNE_FACTURE`, `NUMERO_SERIE`, `NUMERO_ORDRE`, `DESCRIPTION`, `CODE_UTILISATEUR_CREA`, `CODE_AGENCE`, `MONTANT_REMISE`, `MONTANT_TAXE`, `NUMERO_SERIE_DEBUT`, `NUMERO_SERIE_FIN`, `CODE_MAGASIN`, `FUSIONNEE`, `TYPE`) VALUES
(2, '13823082181134', '1112308218936', '', '107', '', '', '', '', '105000.00', '0.00', '1.00', '105000.00', '105000.00', '2021-08-24 00:00:00', '0001-01-01 08:11:00', 0, '0001-01-01 00:00:00', '0001-01-01 08:11:00', 'Location logement (107)', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(3, '2223082191149', '1112308218936', '', '107', '', '', '124210821103653', '', '750.00', '0.00', '1.00', '750.00', '750.00', '2021-08-23 00:00:00', '0001-01-01 09:11:00', 0, '0001-01-01 00:00:00', '0001-01-01 09:11:00', 'TANGUI', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(4, '3123082194351', '1112308218936', '', '107', '', '', '293210821104839', '', '0.00', '0.00', '15.00', '0.00', '0.00', '2021-08-23 00:00:00', '0001-01-01 09:44:00', 0, '0001-01-01 00:00:00', '0001-01-01 09:44:00', 'POISSON', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(5, '49230821151454', 'Client comptoire', '', '', '', '', '124210821103653', '', '1250.00', '0.00', '1.00', '1250.00', '1250.00', '2021-08-23 00:00:00', '0001-01-01 15:15:00', 0, '0001-01-01 00:00:00', '0001-01-01 15:15:00', 'TANGUI', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(6, '49230821151454', 'Client comptoire', '', '', '', '', '293210821104839', '', '500.00', '0.00', '1.00', '500.00', '500.00', '2021-08-23 00:00:00', '0001-01-01 15:15:00', 0, '0001-01-01 00:00:00', '0001-01-01 15:15:00', 'POISSON', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(7, '49230821151454', 'Client comptoire', '', '', '', '', '124210821103653', '', '3750.00', '0.00', '5.00', '750.00', '3750.00', '2021-08-23 00:00:00', '0001-01-01 15:16:00', 0, '0001-01-01 00:00:00', '0001-01-01 15:16:00', 'TANGUI', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(8, '594230821152754', 'Client comptoire', '', '', '', '', '124210821103653', '', '750.00', '0.00', '1.00', '750.00', '750.00', '2021-08-23 00:00:00', '0001-01-01 15:28:00', 0, '0001-01-01 00:00:00', '0001-01-01 15:28:00', 'TANGUI', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(9, '594230821152754', 'Client comptoire', '', '', '', '', '293210821104839', '', '550.00', '0.00', '1.00', '550.00', '550.00', '2021-08-23 00:00:00', '0001-01-01 15:28:00', 0, '0001-01-01 00:00:00', '0001-01-01 15:28:00', 'POISSON', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(10, '668230821181050', 'Client comptoire', '', '', '', '', '293210821104839', '', '7500.00', '0.00', '1.00', '7500.00', '7500.00', '2021-08-23 00:00:00', '0001-01-01 18:11:00', 0, '0001-01-01 00:00:00', '0001-01-01 18:11:00', 'POISSON', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(11, '712240821163845', 'Client comptoire', '', '', '', '', '337240821163838', '', '17000.00', '0.00', '1.00', '17000.00', '17000.00', '2021-08-24 00:00:00', '0001-01-01 16:40:00', 0, '0001-01-01 00:00:00', '0001-01-01 16:40:00', 'LOCATION HEBERGEMENT', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(12, '712240821163845', 'Client comptoire', '', '', '', '', '293210821104839', '', '1500.00', '0.00', '1.00', '1500.00', '1500.00', '2021-08-24 00:00:00', '0001-01-01 16:41:00', 0, '0001-01-01 00:00:00', '0001-01-01 16:41:00', 'POISSON', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(13, '712240821163845', 'Client comptoire', '', '', '', '', '124210821103653', '', '2250.00', '0.00', '3.00', '750.00', '2250.00', '2021-08-24 00:00:00', '0001-01-01 16:41:00', 0, '0001-01-01 00:00:00', '0001-01-01 16:41:00', 'TANGUI', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(14, '84224082116558', 'Client comptoire', '', '', '', '', '337240821163838', '', '0.00', '0.00', '1.00', '0.00', '0.00', '2021-08-24 00:00:00', '0001-01-01 16:55:00', 0, '0001-01-01 00:00:00', '0001-01-01 16:55:00', 'LOCATION HEBERGEMENT', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(15, '86240821171517', 'Client comptoire', '', '', '', '', '337240821163838', '', '25000.00', '0.00', '1.00', '25000.00', '25000.00', '2021-08-24 00:00:00', '0001-01-01 17:15:00', 0, '0001-01-01 00:00:00', '0001-01-01 17:15:00', 'LOCATION HEBERGEMENT', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(16, '8224082117507', '14240821174919', '', '102', '', '', '', '', '15000.00', '0.00', '1.00', '15000.00', '15000.00', '2021-08-25 00:00:00', '0001-01-01 17:50:00', 0, '0001-01-01 00:00:00', '0001-01-01 17:50:00', 'Location logement (102)', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre'),
(17, '91824082117509', '1112308218936', '', '107', '', '', '', '', '35000.00', '0.00', '1.00', '35000.00', '35000.00', '2021-08-25 00:00:00', '0001-01-01 17:50:00', 0, '0001-01-01 00:00:00', '0001-01-01 17:50:00', 'Location logement (107)', '', '', '0.00', '', '', '151130821175930', '0.00', '0.00', '', '', '', '', 'chambre');

-- --------------------------------------------------------

--
-- Table structure for table `main_courante`
--

CREATE TABLE `main_courante` (
  `ID_MAIN_COURANTE` int(20) NOT NULL,
  `CODE_MAIN_COURANTE` varchar(15) NOT NULL,
  `CODE_CLIENT` varchar(30) DEFAULT NULL,
  `CODE_RESERVATION` varchar(30) DEFAULT NULL,
  `CODE_CHAMBRE` varchar(30) DEFAULT NULL,
  `ETAT_CHAMBRE` int(1) DEFAULT NULL,
  `ETAT_RESERVATION` int(1) DEFAULT NULL,
  `DATE_ETAT` datetime DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `ETAT_MAIN_COURANTE` int(11) NOT NULL DEFAULT '0',
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `main_courante`
--

INSERT INTO `main_courante` (`ID_MAIN_COURANTE`, `CODE_MAIN_COURANTE`, `CODE_CLIENT`, `CODE_RESERVATION`, `CODE_CHAMBRE`, `ETAT_CHAMBRE`, `ETAT_RESERVATION`, `DATE_ETAT`, `CODE_AGENCE`, `ETAT_MAIN_COURANTE`, `TYPE`) VALUES
(99, '332108211396', '1351808216575', '5362108211396', '-', 0, 0, '2021-08-20 00:00:00', '151130821175930', 0, 'chambre'),
(100, '41210821131112', '1351808216575', '59210821131112', '-', 0, 0, '2021-08-20 00:00:00', '151130821175930', 0, 'chambre'),
(101, '50210821131114', '1351808216575', '716210821131113', '-', 0, 0, '2021-08-20 00:00:00', '151130821175930', 0, 'chambre'),
(102, '658210821131114', '1351808216575', '927210821131114', '-', 0, 0, '2021-08-20 00:00:00', '151130821175930', 0, 'chambre'),
(106, 'MC5202108211318', '1351808216575', '152210821131853', '104', 1, 1, '2021-08-20 00:00:00', '151130821175930', 1, 'chambre'),
(107, 'MC6632108211646', '1351808216575', '16221082116462', '102', 1, 1, '2021-08-22 00:00:00', '151130821175930', 1, 'chambre'),
(108, 'MC7182108211649', '1351808216575', '16210821164918', '103', 1, 1, '2021-08-22 00:00:00', '151130821175930', 1, 'chambre'),
(109, 'MC8921082116515', '1351808216575', '1921082116515', '104', 1, 1, '2021-08-22 00:00:00', '151130821175930', 1, 'chambre'),
(110, 'MC9162108211658', '1351808216575', '117210821165815', '105', 1, 1, '2021-08-22 00:00:00', '151130821175930', 1, 'chambre'),
(111, 'MC1010220821416', '1351808216575', '14622082141621', '106', 1, 1, '2021-08-22 00:00:00', '151130821175930', 1, 'chambre'),
(112, 'MC1120220821417', '1351808216575', '1482208214179', '101', 1, 1, '2021-08-22 00:00:00', '151130821175930', 1, 'chambre'),
(113, 'MC1236220821536', '1351808216575', '16221082116462', '102', 0, 2, '2021-08-23 00:00:00', '151130821175930', 0, 'chambre'),
(114, 'MC1342208211753', '1351808216575', '150220821175332', '103', 0, 0, '2021-08-24 00:00:00', '151130821175930', 0, 'chambre'),
(115, 'MC1410230821739', '1351808216575', '1023082173956', '106', 1, 1, '2021-08-23 00:00:00', '151130821175930', 1, 'chambre'),
(116, 'MC1516230821893', NULL, '1112308218936', '107', 0, 0, '2021-08-24 00:00:00', '151130821175930', 1, 'chambre'),
(117, '164124082117491', '1351808216575', '14240821174919', '102', 0, 0, '2021-08-25 00:00:00', '151130821175930', 1, 'chambre'),
(118, '171025082116115', '1351808216575', '15325082116115', '103', 0, 0, '2021-08-26 00:00:00', '151130821175930', 0, 'chambre');

-- --------------------------------------------------------

--
-- Table structure for table `main_courante_generale`
--

CREATE TABLE `main_courante_generale` (
  `ID_MAIN_COURANTE_GENERALE` int(20) NOT NULL,
  `CODE_MAIN_COURANTE_GENERALE` varchar(30) NOT NULL,
  `DATE_MAIN_COURANTE` datetime DEFAULT CURRENT_TIMESTAMP,
  `CODE_CHAMBRE` varchar(30) DEFAULT NULL,
  `MONTANT_ACCORDE` decimal(17,2) DEFAULT NULL,
  `ETAT_CHAMBRE` varchar(1) DEFAULT NULL,
  `NOM_CLIENT` varchar(50) DEFAULT NULL,
  `PDJ_FOOD` decimal(17,2) DEFAULT NULL,
  `PDJ_BOISSON` decimal(17,2) DEFAULT NULL,
  `DEJEUNER_FOOD` decimal(17,2) DEFAULT NULL,
  `DEJEUNER_BOISSON` decimal(17,2) DEFAULT NULL,
  `DINER_FOOD` decimal(17,2) DEFAULT NULL,
  `DINER_BOISSON` decimal(17,2) DEFAULT NULL,
  `BANQUET_FOOD` decimal(17,2) DEFAULT NULL,
  `BANQUET_BOISSON` decimal(17,2) DEFAULT NULL,
  `BAR_MATIN` decimal(17,2) DEFAULT NULL,
  `BAR_SOIR` decimal(17,2) DEFAULT NULL,
  `DIVERS` decimal(17,2) DEFAULT NULL,
  `TOTAL_JOUR` decimal(17,2) DEFAULT NULL,
  `REPORT_VEILLE` decimal(17,2) DEFAULT NULL,
  `TOTAL_GENERAL` decimal(17,2) DEFAULT NULL,
  `NUM_RESERVATION` varchar(30) DEFAULT NULL,
  `DEDUCTION` decimal(17,2) DEFAULT NULL,
  `ENCAISSEMENT_ESPECE` decimal(17,2) DEFAULT NULL,
  `ENCAISSEMENT_CHEQUE` decimal(17,2) DEFAULT NULL,
  `ENCAISSEMENT_CARTE_CREDIT` decimal(17,2) DEFAULT NULL,
  `A_REPORTER` decimal(17,2) DEFAULT NULL,
  `OBSERVATIONS` varchar(200) DEFAULT NULL,
  `TYPE_CHAMBRE` varchar(100) DEFAULT NULL,
  `CODE_CLIENT` varchar(30) DEFAULT NULL,
  `INDICE_FREQUENTATION` varchar(50) DEFAULT NULL,
  `INDICE_FREQUENTATION_PCT` varchar(50) DEFAULT NULL,
  `TAUX_OCCUPATION` varchar(50) DEFAULT NULL,
  `TAUX_OCCUPATION_PCT` varchar(50) DEFAULT NULL,
  `CLIENTS_ATTENDUS` varchar(50) DEFAULT NULL,
  `CLIENTS_EN_CHAMBRE` varchar(50) DEFAULT NULL,
  `CHAMBRES_DISPONIBLES` varchar(50) DEFAULT NULL,
  `TOTAL_HORS_SERVICE` varchar(50) DEFAULT NULL,
  `CHAMBRES_HORS_SERVICE` varchar(500) DEFAULT NULL,
  `TOTAL_FICTIVES` varchar(50) DEFAULT NULL,
  `CHAMBRES_FICTIVES` varchar(500) DEFAULT NULL,
  `NOMBRE_MESSAGES` varchar(50) DEFAULT NULL,
  `TOTAL_GRATUITES` varchar(50) DEFAULT NULL,
  `CHAMBRES_GRATUITES` varchar(500) DEFAULT NULL,
  `TOTAL_NON_FACTUREES` varchar(50) DEFAULT NULL,
  `CHAMBRES_NON_FACTUREES` varchar(500) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `ETAT_MAIN_COURANTE` int(5) DEFAULT '0',
  `BAR_RESTAURANT` double NOT NULL DEFAULT '0',
  `SERVICES` double NOT NULL DEFAULT '0',
  `SALON_DE_BEAUTE` double NOT NULL DEFAULT '0',
  `BOUTIQE` double NOT NULL DEFAULT '0',
  `CYBERCAFE` double NOT NULL DEFAULT '0',
  `AUTRES` double NOT NULL DEFAULT '0',
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `main_courante_generale`
--

INSERT INTO `main_courante_generale` (`ID_MAIN_COURANTE_GENERALE`, `CODE_MAIN_COURANTE_GENERALE`, `DATE_MAIN_COURANTE`, `CODE_CHAMBRE`, `MONTANT_ACCORDE`, `ETAT_CHAMBRE`, `NOM_CLIENT`, `PDJ_FOOD`, `PDJ_BOISSON`, `DEJEUNER_FOOD`, `DEJEUNER_BOISSON`, `DINER_FOOD`, `DINER_BOISSON`, `BANQUET_FOOD`, `BANQUET_BOISSON`, `BAR_MATIN`, `BAR_SOIR`, `DIVERS`, `TOTAL_JOUR`, `REPORT_VEILLE`, `TOTAL_GENERAL`, `NUM_RESERVATION`, `DEDUCTION`, `ENCAISSEMENT_ESPECE`, `ENCAISSEMENT_CHEQUE`, `ENCAISSEMENT_CARTE_CREDIT`, `A_REPORTER`, `OBSERVATIONS`, `TYPE_CHAMBRE`, `CODE_CLIENT`, `INDICE_FREQUENTATION`, `INDICE_FREQUENTATION_PCT`, `TAUX_OCCUPATION`, `TAUX_OCCUPATION_PCT`, `CLIENTS_ATTENDUS`, `CLIENTS_EN_CHAMBRE`, `CHAMBRES_DISPONIBLES`, `TOTAL_HORS_SERVICE`, `CHAMBRES_HORS_SERVICE`, `TOTAL_FICTIVES`, `CHAMBRES_FICTIVES`, `NOMBRE_MESSAGES`, `TOTAL_GRATUITES`, `CHAMBRES_GRATUITES`, `TOTAL_NON_FACTUREES`, `CHAMBRES_NON_FACTUREES`, `CODE_AGENCE`, `ETAT_MAIN_COURANTE`, `BAR_RESTAURANT`, `SERVICES`, `SALON_DE_BEAUTE`, `BOUTIQE`, `CYBERCAFE`, `AUTRES`, `TYPE`) VALUES
(68, '321210821131113', '2021-08-20 00:00:00', '-', '35000.00', '0', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '59210821131112', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre'),
(69, '431210821131114', '2021-08-20 00:00:00', '-', '35000.00', '0', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '716210821131113', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre'),
(70, '52210821131115', '2021-08-20 00:00:00', '-', '35000.00', '0', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '927210821131114', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre'),
(74, 'MCG40210821131854', '2021-08-20 00:00:00', '104', '15000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '152210821131853', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'SG', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(75, 'MCG56321082116462', '2021-08-22 00:00:00', '102', '15000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '16221082116462', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'SG', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(76, 'MCG618210821164918', '2021-08-22 00:00:00', '103', '35000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '16210821164918', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(77, 'MCG7921082116515', '2021-08-22 00:00:00', '104', '15000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '1921082116515', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'SG', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(78, 'MCG816210821165815', '2021-08-22 00:00:00', '105', '15000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '117210821165815', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'SG', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(79, 'MCG94622082141622', '2021-08-22 00:00:00', '106', '35000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '14622082141621', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(80, 'MCG10202208214179', '2021-08-22 00:00:00', '101', '15000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '1482208214179', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'SG', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(81, 'MCG118220821175333', '2021-08-24 00:00:00', '103', '35000.00', '0', 'KAMDEM KAMDEM ', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '150220821175332', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre'),
(82, 'MCG12023082173956', '2021-08-23 00:00:00', '106', '35000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '1023082173956', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(83, 'MCG13162308218936', '2021-08-24 00:00:00', '107', '35000.00', '0', 'KAMDEM KAMDEM ', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '1112308218936', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 750, 0, 0, 0, 0, 0, 'chambre'),
(84, '1410240821174919', '2021-08-25 00:00:00', '102', '15000.00', '0', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '14240821174919', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'SG', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(85, '151025082116115', '2021-08-26 00:00:00', '103', '35000.00', '0', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '15325082116115', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre');

-- --------------------------------------------------------

--
-- Table structure for table `main_courante_journaliere`
--

CREATE TABLE `main_courante_journaliere` (
  `ID_MAIN_COURANTE_JOURNALIERE` int(20) NOT NULL,
  `CODE_MAIN_COURANTE_JOURNALIERE` varchar(30) NOT NULL,
  `DATE_MAIN_COURANTE` date DEFAULT NULL,
  `CODE_CHAMBRE` varchar(30) DEFAULT NULL,
  `MONTANT_ACCORDE` decimal(17,2) DEFAULT NULL,
  `ETAT_CHAMBRE` varchar(1) DEFAULT NULL,
  `NOM_CLIENT` varchar(50) DEFAULT NULL,
  `PDJ` decimal(17,2) DEFAULT NULL,
  `DEJEUNER` decimal(17,2) DEFAULT NULL,
  `DINER` decimal(17,2) DEFAULT NULL,
  `CAFE` decimal(17,2) DEFAULT NULL,
  `BAR` decimal(17,2) DEFAULT NULL,
  `CAVE` decimal(17,2) DEFAULT NULL,
  `AUTRE` decimal(17,2) DEFAULT NULL,
  `SOUS_TOTAL1` decimal(17,2) DEFAULT NULL,
  `LOCATION` decimal(17,2) DEFAULT NULL,
  `TELE` decimal(17,2) DEFAULT NULL,
  `FAX` decimal(17,2) DEFAULT NULL,
  `LINGE` decimal(17,2) DEFAULT NULL,
  `DIVERS` decimal(17,2) DEFAULT NULL,
  `SOUS_TOTAL2` decimal(17,2) DEFAULT NULL,
  `TOTAL_JOUR` decimal(17,2) DEFAULT NULL,
  `REPORT_VEILLE` decimal(17,2) DEFAULT NULL,
  `TOTAL_GENERAL` decimal(17,2) DEFAULT NULL,
  `NUM_RESERVATION` varchar(30) DEFAULT NULL,
  `DEDUCTION` decimal(17,2) DEFAULT NULL,
  `ENCAISSEMENT_ESPECE` decimal(17,2) DEFAULT NULL,
  `ENCAISSEMENT_CHEQUE` decimal(17,2) DEFAULT NULL,
  `ENCAISSEMENT_CARTE_CREDIT` decimal(17,2) DEFAULT NULL,
  `DEBITEUR` decimal(17,2) DEFAULT NULL,
  `ARRHES` decimal(17,2) DEFAULT NULL,
  `A_REPORTER` decimal(17,2) DEFAULT NULL,
  `OBSERVATIONS` varchar(200) DEFAULT NULL,
  `TYPE_CHAMBRE` varchar(50) DEFAULT NULL,
  `CODE_CLIENT` varchar(30) DEFAULT NULL,
  `INDICE_FREQUENTATION` varchar(50) DEFAULT NULL,
  `INDICE_FREQUENTATION_PCT` varchar(50) DEFAULT NULL,
  `TAUX_OCCUPATION` varchar(50) DEFAULT NULL,
  `TAUX_OCCUPATION_PCT` varchar(50) DEFAULT NULL,
  `CLIENTS_ATTENDUS` varchar(10) DEFAULT NULL,
  `CLIENTS_EN_CHAMBRE` varchar(10) DEFAULT NULL,
  `CHAMBRES_DISPONIBLES` varchar(10) DEFAULT NULL,
  `TOTAL_HORS_SERVICE` varchar(10) DEFAULT NULL,
  `CHAMBRES_HORS_SERVICE` varchar(500) DEFAULT NULL,
  `TOTAL_FICTIVES` varchar(10) DEFAULT NULL,
  `CHAMBRES_FICTIVES` varchar(500) DEFAULT NULL,
  `NOMBRE_MESSAGES` varchar(10) DEFAULT NULL,
  `TOTAL_GRATUITES` varchar(10) DEFAULT NULL,
  `CHAMBRES_GRATUITES` varchar(500) DEFAULT NULL,
  `TOTAL_NON_FACTUREES` varchar(10) DEFAULT NULL,
  `CHAMBRES_NON_FACTUREES` varchar(500) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `ETAT_MAIN_COURANTE` int(5) NOT NULL DEFAULT '0',
  `BAR_RESTAURANT` double NOT NULL DEFAULT '0',
  `SERVICES` double NOT NULL DEFAULT '0',
  `SALON_DE_BEAUTE` double NOT NULL DEFAULT '0',
  `BOUTIQE` double NOT NULL DEFAULT '0',
  `CYBERCAFE` double NOT NULL DEFAULT '0',
  `AUTRES` double NOT NULL DEFAULT '0',
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `main_courante_journaliere`
--

INSERT INTO `main_courante_journaliere` (`ID_MAIN_COURANTE_JOURNALIERE`, `CODE_MAIN_COURANTE_JOURNALIERE`, `DATE_MAIN_COURANTE`, `CODE_CHAMBRE`, `MONTANT_ACCORDE`, `ETAT_CHAMBRE`, `NOM_CLIENT`, `PDJ`, `DEJEUNER`, `DINER`, `CAFE`, `BAR`, `CAVE`, `AUTRE`, `SOUS_TOTAL1`, `LOCATION`, `TELE`, `FAX`, `LINGE`, `DIVERS`, `SOUS_TOTAL2`, `TOTAL_JOUR`, `REPORT_VEILLE`, `TOTAL_GENERAL`, `NUM_RESERVATION`, `DEDUCTION`, `ENCAISSEMENT_ESPECE`, `ENCAISSEMENT_CHEQUE`, `ENCAISSEMENT_CARTE_CREDIT`, `DEBITEUR`, `ARRHES`, `A_REPORTER`, `OBSERVATIONS`, `TYPE_CHAMBRE`, `CODE_CLIENT`, `INDICE_FREQUENTATION`, `INDICE_FREQUENTATION_PCT`, `TAUX_OCCUPATION`, `TAUX_OCCUPATION_PCT`, `CLIENTS_ATTENDUS`, `CLIENTS_EN_CHAMBRE`, `CHAMBRES_DISPONIBLES`, `TOTAL_HORS_SERVICE`, `CHAMBRES_HORS_SERVICE`, `TOTAL_FICTIVES`, `CHAMBRES_FICTIVES`, `NOMBRE_MESSAGES`, `TOTAL_GRATUITES`, `CHAMBRES_GRATUITES`, `TOTAL_NON_FACTUREES`, `CHAMBRES_NON_FACTUREES`, `CODE_AGENCE`, `ETAT_MAIN_COURANTE`, `BAR_RESTAURANT`, `SERVICES`, `SALON_DE_BEAUTE`, `BOUTIQE`, `CYBERCAFE`, `AUTRES`, `TYPE`) VALUES
(1, 'MCJ152308218936', '2021-08-24', '107', '35000.00', '0', 'KAMDEM KAMDEM ', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '1112308218936', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 750, 0, 0, 0, 0, 0, 'chambre'),
(2, '32223082181134', '2021-08-25', '107', '35000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '1112308218936', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre'),
(3, '36240821174919', '2021-08-25', '102', '15000.00', '0', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '14240821174919', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'SG', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 0, 0, 0, 0, 0, 0, 'chambre'),
(4, '52124082117508', '2021-08-26', '102', '15000.00', '0', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '14240821174919', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'SG', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre'),
(5, 'MCJ152308218936', '2021-08-24', '107', '35000.00', '0', 'KAMDEM KAMDEM ', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '1112308218936', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 1, 750, 0, 0, 0, 0, 0, 'chambre'),
(6, '32223082181134', '2021-08-25', '107', '35000.00', '1', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '1112308218936', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre'),
(7, '73725082116115', '2021-08-26', '103', '35000.00', '0', 'KAMDEM KAMDEM', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '15325082116115', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '0.00', '', 'GC', '1351808216575', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '151130821175930', 0, 0, 0, 0, 0, 0, 0, 'chambre');

-- --------------------------------------------------------

--
-- Table structure for table `mode_reglement`
--

CREATE TABLE `mode_reglement` (
  `ID_MODE_PAIMENT` int(20) NOT NULL,
  `CODE_MODE` varchar(30) DEFAULT NULL,
  `LIBELLE_MODE` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `monnaie`
--

CREATE TABLE `monnaie` (
  `ID_MONNAIE` int(11) NOT NULL,
  `PAYS` varchar(100) DEFAULT NULL,
  `MONNAIE` varchar(100) DEFAULT NULL,
  `CODE_MONNAIE` varchar(100) DEFAULT NULL,
  `SYMBOLE` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `monnaie`
--

INSERT INTO `monnaie` (`ID_MONNAIE`, `PAYS`, `MONNAIE`, `CODE_MONNAIE`, `SYMBOLE`) VALUES
(2, 'America', 'Dollars', 'USD', '$'),
(4, 'Argentina', 'Pesos', 'ARS', '$'),
(6, 'Australia', 'Dollars', 'AUD', '$'),
(8, 'Bahamas', 'Dollars', 'BSD', '$'),
(9, 'Barbados', 'Dollars', 'BBD', '$'),
(10, 'Belarus', 'Rubles', 'BYR', 'p.'),
(11, 'Belgium', 'Euro', 'EUR', '€'),
(12, 'Beliz', 'Dollars', 'BZD', 'BZ$'),
(13, 'Bermuda', 'Dollars', 'BMD', '$'),
(14, 'Bolivia', 'Bolivianos', 'BOB', '$b'),
(15, 'Bosnia and Herzegovina', 'Convertible Marka', 'BAM', 'KM'),
(16, 'Botswana', 'Pula', 'BWP', 'P'),
(17, 'Bulgaria', 'Leva', 'BGN', '??'),
(18, 'Brazil', 'Reais', 'BRL', 'R$'),
(19, 'Britain (United Kingdom)', 'Pounds', 'GBP', '£'),
(20, 'Brunei Darussalam', 'Dollars', 'BND', '$'),
(21, 'Cambodia', 'Riels', 'KHR', '?'),
(22, 'Canada', 'Dollars', 'CAD', '$'),
(23, 'Cayman Islands', 'Dollars', 'KYD', '$'),
(24, 'Chile', 'Pesos', 'CLP', '$'),
(25, 'China', 'Yuan Renminbi', 'CNY', '¥'),
(26, 'Colombia', 'Pesos', 'COP', '$'),
(27, 'Costa Rica', 'Colón', 'CRC', '?'),
(28, 'Croatia', 'Kuna', 'HRK', 'kn'),
(29, 'Cuba', 'Pesos', 'CUP', '?'),
(30, 'Cameroon', 'XAF', 'XAF', 'FCFA'),
(31, 'Czech Republic', 'Koruny', 'CZK', 'K?'),
(32, 'Denmark', 'Kroner', 'DKK', 'kr'),
(33, 'Dominican Republic', 'Pesos', 'DOP ', 'RD$'),
(34, 'East Caribbean', 'Dollars', 'XCD', '$'),
(35, 'Egypt', 'Pounds', 'EGP', '£'),
(36, 'El Salvador', 'Colones', 'SVC', '$'),
(37, 'England (United Kingdom)', 'Pounds', 'GBP', '£'),
(38, 'Euro', 'Euro', 'EUR', '€'),
(39, 'Falkland Islands', 'Pounds', 'FKP', '£'),
(40, 'Fiji', 'Dollars', 'FJD', '$'),
(41, 'France', 'Euro', 'EUR', '€'),
(42, 'Ghana', 'Cedis', 'GHC', '¢'),
(43, 'Gibraltar', 'Pounds', 'GIP', '£'),
(45, 'Guatemala', 'Quetzales', 'GTQ', 'Q'),
(46, 'Guernsey', 'Pounds', 'GGP', '£'),
(47, 'Guyana', 'Dollars', 'GYD', '$'),
(48, 'Holland (Netherlands)', 'Euro', 'EUR', '€'),
(49, 'Honduras', 'Lempiras', 'HNL', 'L'),
(51, 'Hungary', 'Forint', 'HUF', 'Ft'),
(52, 'Iceland', 'Kronur', 'ISK', 'kr'),
(53, 'India', 'Rupees', 'INR', 'Rp'),
(54, 'Indonesia', 'Rupiahs', 'IDR', 'Rp'),
(55, 'Iran', 'Rials', 'IRR', '?'),
(56, 'Ireland', 'Euro', 'EUR', '€'),
(57, 'Isle of Man', 'Pounds', 'IMP', '£'),
(58, 'Israel', 'New Shekels', 'ILS', '?'),
(59, 'Italy', 'Euro', 'EUR', '€'),
(60, 'Jamaica', 'Dollars', 'JMD', 'J$'),
(61, 'Japan', 'Yen', 'JPY', '¥'),
(62, 'Jersey', 'Pounds', 'JEP', '£'),
(63, 'Kazakhstan', 'Tenge', 'KZT', '??'),
(64, 'Korea (North)', 'Won', 'KPW', '?'),
(65, 'Korea (South)', 'Won', 'KRW', '?'),
(66, 'Kyrgyzstan', 'Soms', 'KGS', '??'),
(67, 'Laos', 'Kips', 'LAK', '?'),
(68, 'Latvia', 'Lati', 'LVL', 'Ls'),
(69, 'Lebanon', 'Pounds', 'LBP', '£'),
(70, 'Liberia', 'Dollars', 'LRD', '$'),
(71, 'Liechtenstein', 'Switzerland Francs', 'CHF', 'CHF'),
(72, 'Lithuania', 'Litai', 'LTL', 'Lt'),
(73, 'Luxembourg', 'Euro', 'EUR', '€'),
(74, 'Macedonia', 'Denars', 'MKD', '???'),
(75, 'Malaysia', 'Ringgits', 'MYR', 'RM'),
(76, 'Malta', 'Euro', 'EUR', '€'),
(77, 'Mauritius', 'Rupees', 'MUR', '?'),
(78, 'Mexico', 'Pesos', 'MXN', '$'),
(79, 'Mongolia', 'Tugriks', 'MNT', '?'),
(80, 'Mozambique', 'Meticais', 'MZN', 'MT'),
(81, 'Namibia', 'Dollars', 'NAD', '$'),
(82, 'Nepal', 'Rupees', 'NPR', '?'),
(83, 'Netherlands Antilles', 'Guilders', 'ANG', 'ƒ'),
(84, 'Netherlands', 'Euro', 'EUR', '€'),
(85, 'New Zealand', 'Dollars', 'NZD', '$'),
(86, 'Nicaragua', 'Cordobas', 'NIO', 'C$'),
(87, 'Nigeria', 'Nairas', 'NGN', '?'),
(88, 'North Korea', 'Won', 'KPW', '?'),
(89, 'Norway', 'Krone', 'NOK', 'kr'),
(90, 'Oman', 'Rials', 'OMR', '?'),
(91, 'Pakistan', 'Rupees', 'PKR', '?'),
(92, 'Panama', 'Balboa', 'PAB', 'B/.'),
(93, 'Paraguay', 'Guarani', 'PYG', 'Gs'),
(94, 'Peru', 'Nuevos Soles', 'PEN', 'S/.'),
(95, 'Philippines', 'Pesos', 'PHP', 'Php'),
(96, 'Poland', 'Zlotych', 'PLN', 'z?'),
(97, 'Qatar', 'Rials', 'QAR', '?'),
(98, 'Romania', 'New Lei', 'RON', 'lei'),
(99, 'Russia', 'Rubles', 'RUB', '???'),
(100, 'Saint Helena', 'Pounds', 'SHP', '£'),
(101, 'Saudi Arabia', 'Riyals', 'SAR', '?'),
(102, 'Serbia', 'Dinars', 'RSD', '???.'),
(103, 'Seychelles', 'Rupees', 'SCR', '?'),
(104, 'Singapore', 'Dollars', 'SGD', '$'),
(105, 'Slovenia', 'Euro', 'EUR', '€'),
(106, 'Solomon Islands', 'Dollars', 'SBD', '$'),
(107, 'Somalia', 'Shillings', 'SOS', 'S'),
(108, 'South Africa', 'Rand', 'ZAR', 'R'),
(109, 'South Korea', 'Won', 'KRW', '?'),
(110, 'Spain', 'Euro', 'EUR', '€'),
(111, 'Sri Lanka', 'Rupees', 'LKR', '?'),
(112, 'Sweden', 'Kronor', 'SEK', 'kr'),
(113, 'Switzerland', 'Francs', 'CHF', 'CHF'),
(114, 'Suriname', 'Dollars', 'SRD', '$'),
(115, 'Syria', 'Pounds', 'SYP', '£'),
(116, 'Taiwan', 'New Dollars', 'TWD', 'NT$'),
(117, 'Thailand', 'Baht', 'THB', '?'),
(118, 'Trinidad and Tobago', 'Dollars', 'TTD', 'TT$'),
(119, 'Turkey', 'Lira', 'TRY', 'TL'),
(120, 'Turkey', 'Liras', 'TRL', '£'),
(121, 'Tuvalu', 'Dollars', 'TVD', '$'),
(122, 'Ukraine', 'Hryvnia', 'UAH', '?'),
(123, 'United Kingdom', 'Pounds', 'GBP', '£'),
(124, 'United States of America', 'Dollars', 'USD', '$'),
(125, 'Uruguay', 'Pesos', 'UYU', '$U'),
(126, 'Uzbekistan', 'Sums', 'UZS', '??'),
(127, 'Vatican City', 'Euro', 'EUR', '€'),
(128, 'Venezuela', 'Bolivares Fuertes', 'VEF', 'Bs'),
(129, 'Vietnam', 'Dong', 'VND', '?'),
(130, 'Yemen', 'Rials', 'YER', '?'),
(131, 'Zimbabwe', 'Zimbabwe Dollars', 'ZWD', 'Z$'),
(132, 'India', 'Rupees', 'INR', '?'),
(133, 'cameroon', 'cameroon', 'XAF', 'FCFA');

-- --------------------------------------------------------

--
-- Table structure for table `mvt_compte`
--

CREATE TABLE `mvt_compte` (
  `ID_MVT_COMPTE` int(11) NOT NULL,
  `NUM_COMPTE` varchar(30) NOT NULL,
  `CODE_TIERS` varchar(30) NOT NULL,
  `TYPE_TIERS` varchar(30) NOT NULL,
  `DATE_MVT` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LIBELLE_MVT` varchar(50) NOT NULL,
  `MONTANT_MVT` double NOT NULL,
  `SOLDE_AVANT_MVT` double NOT NULL,
  `TYPE_MVT` varchar(30) NOT NULL,
  `CODE_AGENCE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `nationalite`
--

CREATE TABLE `nationalite` (
  `CODE_NATIONALITE` varchar(30) DEFAULT NULL,
  `LIBELLE_NATIONALITE` varchar(50) DEFAULT NULL,
  `GROUPE` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `occupation_chambre`
--

CREATE TABLE `occupation_chambre` (
  `ID_OCCUPATION_CHAMBRE` int(20) NOT NULL,
  `CODE_OCCUPATION_CHAMBRE` varchar(30) NOT NULL,
  `CODE_RESERVATION` varchar(30) DEFAULT NULL,
  `CODE_CHAMBRE` varchar(30) DEFAULT NULL,
  `MONTANT_HT` decimal(17,2) DEFAULT NULL,
  `TAXE` decimal(17,2) DEFAULT NULL,
  `MONTANT_TTC` decimal(17,2) DEFAULT NULL,
  `DATE_OCCUPATION` datetime DEFAULT CURRENT_TIMESTAMP,
  `ETAT_CHAMBRE` varchar(1) DEFAULT NULL,
  `OBSERVATIONS` varchar(200) DEFAULT NULL,
  `COMMENTAIRE1` varchar(200) DEFAULT NULL,
  `COMMENTAIRE2` varchar(200) DEFAULT NULL,
  `COMMENTAIRE3` varchar(200) DEFAULT NULL,
  `COMMENTAIRE4` varchar(200) DEFAULT NULL,
  `DATE_LIBERATION` datetime DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `DATE_PREMIERE_ARRIVEE` datetime DEFAULT NULL,
  `TYPE_RESERVATION` varchar(1) DEFAULT NULL,
  `PDJ_INCLUS` varchar(1) DEFAULT NULL,
  `TAXE_SEJOURS_INCLUS` varchar(1) DEFAULT NULL,
  `TVA_INCLUS` varchar(1) DEFAULT NULL,
  `CODE_CLIENT_REEL` varchar(30) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `occupation_chambre`
--

INSERT INTO `occupation_chambre` (`ID_OCCUPATION_CHAMBRE`, `CODE_OCCUPATION_CHAMBRE`, `CODE_RESERVATION`, `CODE_CHAMBRE`, `MONTANT_HT`, `TAXE`, `MONTANT_TTC`, `DATE_OCCUPATION`, `ETAT_CHAMBRE`, `OBSERVATIONS`, `COMMENTAIRE1`, `COMMENTAIRE2`, `COMMENTAIRE3`, `COMMENTAIRE4`, `DATE_LIBERATION`, `CODE_UTILISATEUR_CREA`, `DATE_PREMIERE_ARRIVEE`, `TYPE_RESERVATION`, `PDJ_INCLUS`, `TAXE_SEJOURS_INCLUS`, `TVA_INCLUS`, `CODE_CLIENT_REEL`, `CODE_AGENCE`, `TYPE`) VALUES
(1, '1314082184537', '1114082184537', '102', '0.00', '0.00', '0.00', '2021-08-13 00:00:00', '1', '', '', '', '', '', '2021-08-13 00:00:00', '', '2021-08-13 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(2, 'OC222140821175641', '1114082184537', '102', '0.00', '0.00', '0.00', '2021-08-14 00:00:00', '1', '', '', '', '', '', '2021-08-14 00:00:00', '', '2021-08-14 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(3, '325140821205437', '10140821205437', '102', '0.00', '0.00', '0.00', '2021-08-15 00:00:00', '1', '', '', '', '', '', '2021-08-15 00:00:00', '', '2021-08-15 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(4, 'OC41915082133347', '1114082184537', '102', '0.00', '0.00', '0.00', '2021-08-15 00:00:00', '0', '', '', '', '', '', '2021-08-15 00:00:00', '', '2021-08-15 00:00:00', '', '', '', '', '1814082184312', '151130821175930', 'chambre'),
(5, '5815082163451', '13115082163451', '103', '0.00', '0.00', '0.00', '2021-08-15 00:00:00', '1', '', '', '', '', '', '2021-08-15 00:00:00', '', '2021-08-15 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(6, 'OC631508218735', '13115082163451', '103', '0.00', '0.00', '0.00', '2021-08-15 00:00:00', '1', '', '', '', '', '', '2021-08-15 00:00:00', '', '2021-08-15 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(7, 'OC75915082183012', '13115082163451', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '1814082184312', '151130821175930', 'chambre'),
(8, '86150821102450', '16150821102450', NULL, '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(9, '99150821104141', '131150821104141', NULL, '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(10, '1020150821104625', '170150821104625', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(11, '118150821131924', '18150821131924', '102', '0.00', '0.00', '0.00', '2021-08-15 00:00:00', '1', '', '', '', '', '', '2021-08-15 00:00:00', '', '2021-08-15 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(12, 'OC1230150821131940', '18150821131924', '102', '0.00', '0.00', '0.00', '2021-08-15 00:00:00', '1', '', '', '', '', '', '2021-08-15 00:00:00', '', '2021-08-15 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(13, '131150821132346', '111150821132346', '102', '0.00', '0.00', '0.00', '2021-08-15 00:00:00', '1', '', '', '', '', '', '2021-08-15 00:00:00', '', '2021-08-15 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(14, 'OC1493150821132358', '111150821132346', '102', '0.00', '0.00', '0.00', '2021-08-15 00:00:00', '1', '', '', '', '', '', '2021-08-15 00:00:00', '', '2021-08-15 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(15, 'OC157715082114752', '1515082114752', '101', '0.00', '0.00', '0.00', '2021-08-17 00:00:00', '1', '', '', '', '', '', '2021-08-17 00:00:00', '', '2021-08-17 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(16, 'OC16311508211494', '1515082114752', '101', '0.00', '0.00', '0.00', '2021-08-18 00:00:00', '0', '', '', '', '', '', '2021-08-18 00:00:00', '', '2021-08-18 00:00:00', '', '', '', '', '1814082184312', '151130821175930', 'chambre'),
(17, 'OC1720150821141156', '165150821141156', '101', '0.00', '0.00', '0.00', '2021-08-18 00:00:00', '1', '', '', '', '', '', '2021-08-18 00:00:00', '', '2021-08-18 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(18, '1815150821141212', '115150821141212', '101', '0.00', '0.00', '0.00', '2021-08-18 00:00:00', '1', '', '', '', '', '', '2021-08-18 00:00:00', '', '2021-08-18 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(19, 'OC199150821141250', '165150821141156', '101', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '0', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '1814082184312', '151130821175930', 'chambre'),
(20, 'OC2034150821151418', '111150821151418', '102', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '1', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(21, '2138150821151518', '138150821151518', '103', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '1', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(22, '225150821151546', '35150821151546', '102', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '1', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(23, '2333150821155140', '333150821155140', '103', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '1', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(24, 'OC2415150821155231', '138150821151518', '103', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '1', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(25, 'OC25315082116615', '1315082116615', '102', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '1', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(26, '26215082116858', '1215082116858', '102', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '1', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(27, '2739150821161213', '139150821161213', '102', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '1', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(28, 'OC2837150821161230', '139150821161213', '102', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '1', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(29, '2971150821161433', '171150821161433', '101', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '1', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(30, '30015082116153', '34715082116153', '102', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '1', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(31, 'OC317150821162418', '37150821162418', '101', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(32, 'OC3251150821164242', '151150821164242', '102', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(33, '332415082116440', '12415082116440', '101', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(34, '3455150821164929', '318150821164929', '101', '0.00', '0.00', '0.00', '2021-08-24 00:00:00', '1', '', '', '', '', '', '2021-08-24 00:00:00', '', '2021-08-24 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(35, 'OC3548150821165757', '151150821164242', '102', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '0', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '1814082184312', '151130821175930', 'chambre'),
(36, '369150821165847', '39150821165847', '101', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '1', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(37, '375215082117036', '35215082117036', '101', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '1', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(38, '3861508211714', '361508211714', '101', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '1', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(39, 'OC39015082117145', '12415082116440', '101', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '1', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(40, '407015082117221', '17015082117221', '103', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '1', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(41, '4169150821171251', '169150821171251', '101', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '1', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(42, '4254150821171328', '355150821171328', '101', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '1', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(43, '4322150821171424', '322150821171424', '101', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '1', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(44, '4443150821171441', '327150821171441', '101', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '1', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(45, '4516150821171516', '316150821171516', '101', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '1', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(46, '4625150821171650', '325150821171650', '101', '0.00', '0.00', '0.00', '2021-08-28 00:00:00', '1', '', '', '', '', '', '2021-08-28 00:00:00', '', '2021-08-28 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(47, '470150821171659', '30150821171659', '101', '0.00', '0.00', '0.00', '2021-08-28 00:00:00', '1', '', '', '', '', '', '2021-08-28 00:00:00', '', '2021-08-28 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(48, '486150821171720', '36150821171720', '101', '0.00', '0.00', '0.00', '2021-08-28 00:00:00', '1', '', '', '', '', '', '2021-08-28 00:00:00', '', '2021-08-28 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(49, 'OC493150821171726', '169150821171251', '101', '0.00', '0.00', '0.00', '2021-08-28 00:00:00', '1', '', '', '', '', '', '2021-08-28 00:00:00', '', '2021-08-28 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(50, '5053150821171741', '153150821171741', '101', '0.00', '0.00', '0.00', '2021-08-28 00:00:00', '1', '', '', '', '', '', '2021-08-28 00:00:00', '', '2021-08-28 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(51, '5112150821171747', '112150821171747', '101', '0.00', '0.00', '0.00', '2021-08-28 00:00:00', '1', '', '', '', '', '', '2021-08-28 00:00:00', '', '2021-08-28 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(52, '523150821171757', '13150821171757', '101', '0.00', '0.00', '0.00', '2021-08-28 00:00:00', '1', '', '', '', '', '', '2021-08-28 00:00:00', '', '2021-08-28 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(53, '537715082117190', '17715082117190', '101', '0.00', '0.00', '0.00', '2021-08-29 00:00:00', '1', '', '', '', '', '', '2021-08-29 00:00:00', '', '2021-08-29 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(54, 'OC542150821172015', '12150821172015', '103', '0.00', '0.00', '0.00', '2021-08-30 00:00:00', '1', '', '', '', '', '', '2021-08-30 00:00:00', '', '2021-08-30 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(55, '551016082124015', '1716082124015', '102', '0.00', '0.00', '0.00', '2021-08-31 00:00:00', '1', '', '', '', '', '', '2021-08-31 00:00:00', '', '2021-08-31 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(56, '56416082131819', '1016082131818', '102', '0.00', '0.00', '0.00', '2021-09-01 00:00:00', '1', '', '', '', '', '', '2021-09-01 00:00:00', '', '2021-09-01 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(57, '57321608213380', '1401608213380', '102', '0.00', '0.00', '0.00', '2021-09-02 00:00:00', '1', '', '', '', '', '', '2021-09-02 00:00:00', '', '2021-09-02 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(58, '58016082134319', '12216082134319', '102', '0.00', '0.00', '0.00', '2021-09-03 00:00:00', '1', '', '', '', '', '', '2021-09-03 00:00:00', '', '2021-09-03 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(59, '596416082134648', '16416082134648', '101', '0.00', '0.00', '0.00', '2021-09-04 00:00:00', '1', '', '', '', '', '', '2021-09-04 00:00:00', '', '2021-09-04 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(60, 'OC605116082134922', '15116082134922', '103', '0.00', '0.00', '0.00', '2021-09-05 00:00:00', '1', '', '', '', '', '', '2021-09-05 00:00:00', '', '2021-09-05 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(61, 'OC61516082135122', '15116082134922', '103', '0.00', '0.00', '0.00', '2021-09-06 00:00:00', '0', '', '', '', '', '', '2021-09-06 00:00:00', '', '2021-09-06 00:00:00', '', '', '', '', '1814082184312', '151130821175930', 'chambre'),
(62, 'OC621316082143934', '11216082143934', '101', '0.00', '0.00', '0.00', '2021-09-06 00:00:00', '1', '', '', '', '', '', '2021-09-06 00:00:00', '', '2021-09-06 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(63, '638316082161024', '11116082161024', '103', '0.00', '0.00', '0.00', '2021-09-06 00:00:00', '1', '', '', '', '', '', '2021-09-06 00:00:00', '', '2021-09-06 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(64, '645416082161138', '15416082161138', '103', '0.00', '0.00', '0.00', '2021-09-06 00:00:00', '1', '', '', '', '', '', '2021-09-06 00:00:00', '', '2021-09-06 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(65, 'OC652916082163451', '11216082143934', '101', '0.00', '0.00', '0.00', '2021-09-08 00:00:00', '0', '', '', '', '', '', '2021-09-08 00:00:00', '', '2021-09-08 00:00:00', '', '', '', '', '1814082184312', '151130821175930', 'chambre'),
(66, '661316082164027', '17816082164027', '101', '0.00', '0.00', '0.00', '2021-09-08 00:00:00', '1', '', '', '', '', '', '2021-09-08 00:00:00', '', '2021-09-08 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(67, '671016082164212', '11016082164212', '103', '0.00', '0.00', '0.00', '2021-09-08 00:00:00', '1', '', '', '', '', '', '2021-09-08 00:00:00', '', '2021-09-08 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(68, 'OC684616082164622', '11016082164212', '103', '0.00', '0.00', '0.00', '2021-09-08 00:00:00', '1', '', '', '', '', '', '2021-09-08 00:00:00', '', '2021-09-08 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(69, 'OC691216082164930', '11016082164212', '103', '0.00', '0.00', '0.00', '2021-09-12 00:00:00', '0', '', '', '', '', '', '2021-09-12 00:00:00', '', '2021-09-12 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(70, 'OC701916082165028', '1916082165028', '102', '0.00', '0.00', '0.00', '2021-09-12 00:00:00', '1', '', '', '', '', '', '2021-09-12 00:00:00', '', '2021-09-12 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(71, '71716082165038', '13716082165038', '102', '0.00', '0.00', '0.00', '2021-09-12 00:00:00', '1', '', '', '', '', '', '2021-09-12 00:00:00', '', '2021-09-12 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(72, '723316082165049', '13316082165049', '102', '0.00', '0.00', '0.00', '2021-09-12 00:00:00', '1', '', '', '', '', '', '2021-09-12 00:00:00', '', '2021-09-12 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(73, '7341608216512', '141608216512', '102', '0.00', '0.00', '0.00', '2021-09-12 00:00:00', '1', '', '', '', '', '', '2021-09-12 00:00:00', '', '2021-09-12 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(74, '741416082165111', '11416082165111', '102', '0.00', '0.00', '0.00', '2021-09-12 00:00:00', '1', '', '', '', '', '', '2021-09-12 00:00:00', '', '2021-09-12 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(75, '75416082165232', '1416082165232', '102', '0.00', '0.00', '0.00', '2021-09-13 00:00:00', '1', '', '', '', '', '', '2021-09-13 00:00:00', '', '2021-09-13 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(76, '762616082165240', '13016082165240', '102', '0.00', '0.00', '0.00', '2021-09-13 00:00:00', '1', '', '', '', '', '', '2021-09-13 00:00:00', '', '2021-09-13 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(77, '77216082165252', '1816082165252', '102', '0.00', '0.00', '0.00', '2021-09-13 00:00:00', '1', '', '', '', '', '', '2021-09-13 00:00:00', '', '2021-09-13 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(78, '78161608217954', '171608217954', '101', '0.00', '0.00', '0.00', '2021-09-14 00:00:00', '1', '', '', '', '', '', '2021-09-14 00:00:00', '', '2021-09-14 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(79, '793216082172323', '1316082172323', '103', '0.00', '0.00', '0.00', '2021-09-15 00:00:00', '1', '', '', '', '', '', '2021-09-15 00:00:00', '', '2021-09-15 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(80, 'OC803316082172629', '13316082172629', '102', '0.00', '0.00', '0.00', '2021-09-16 00:00:00', '1', '', '', '', '', '', '2021-09-16 00:00:00', '', '2021-09-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(81, '814016082173440', '17416082173440', '101', '0.00', '0.00', '0.00', '2021-09-18 00:00:00', '1', '', '', '', '', '', '2021-09-18 00:00:00', '', '2021-09-18 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(82, 'OC824716082173750', '17416082173440', '101', '0.00', '0.00', '0.00', '2021-09-19 00:00:00', '1', '', '', '', '', '', '2021-09-19 00:00:00', '', '2021-09-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(83, '8351608217381', '151608217381', '101', '0.00', '0.00', '0.00', '2021-09-19 00:00:00', '1', '', '', '', '', '', '2021-09-19 00:00:00', '', '2021-09-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(84, '8411608217388', '181608217388', '101', '0.00', '0.00', '0.00', '2021-09-19 00:00:00', '1', '', '', '', '', '', '2021-09-19 00:00:00', '', '2021-09-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(85, '854316082173815', '14316082173815', '101', '0.00', '0.00', '0.00', '2021-09-19 00:00:00', '1', '', '', '', '', '', '2021-09-19 00:00:00', '', '2021-09-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(86, '863116082173919', '19116082173919', '101', '0.00', '0.00', '0.00', '2021-09-20 00:00:00', '1', '', '', '', '', '', '2021-09-20 00:00:00', '', '2021-09-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(87, '879616082173926', '19616082173926', '101', '0.00', '0.00', '0.00', '2021-09-20 00:00:00', '1', '', '', '', '', '', '2021-09-20 00:00:00', '', '2021-09-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(88, 'OC884017082112449', '12317082112449', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(89, '89117082112554', '1117082112554', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(90, '901180821112335', '124180821112335', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(91, '9159180821113330', '323180821113330', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(92, '9226180821114342', '30180821114342', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(93, '9334180821114428', '534180821114428', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(94, '9435180821131343', '35180821131343', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(95, '953180821131558', '33180821131558', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(96, '9643180821131810', '343180821131810', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(97, '977180821131832', '39180821131832', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(98, '9813180821143930', '313180821143930', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(99, '9912180821144343', '512180821144343', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(100, '1001180821144413', '71180821144413', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(101, '10117180821144424', '917180821144424', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(102, '1021180821144434', '111180821144434', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(103, '1035180821145135', '133180821145135', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(104, '1042718082114524', '32718082114524', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(105, '1059118082114535', '5118082114535', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(106, '1068018082115437', '1518082115437', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(107, '1075518082115513', '35518082115513', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(108, '1080180821151035', '314180821151029', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(109, '1098180821151258', '342180821151256', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(110, '1103518082115190', '111180821151858', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(111, '11139180821151925', '32180821151922', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(112, '11211180821152719', '13180821152716', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(113, '113918082115282', '312180821152743', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(114, '11449180821153844', '547180821153841', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(115, '1152718082115439', '3118082115436', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(116, '1166180821154821', '340180821154818', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(117, '11728180821154846', '521180821154843', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(118, '1186180821154856', '757180821154854', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(119, '119018082115492', '91118082115490', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(120, '12026180821155516', '97180821155514', NULL, '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(121, '1211718082115583', '928180821155758', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(122, '12214180821155826', '1113180821155824', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(123, '1231718082116042', '1018082116039', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(124, '1241118082116047', '3318082116046', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(125, '1252918082116056', '5618082116054', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(126, '1262719082175343', '31219082175339', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(127, '127431908218235', '1381908218233', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(128, '1283319082185132', '17219082185130', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(129, '1296190821124042', '18190821124039', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(130, '1301419082113439', '1819082113437', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(131, '13147190821134135', '120190821134134', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(132, '132319082113439', '12319082113434', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(133, '1331219082114330', '1219082114330', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(134, '1345190821144317', '110190821144317', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(135, '1356190821144524', '143190821144524', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(136, '13636190821152157', '136190821152157', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(137, '1377190821155857', '1522190821155857', '-', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(138, 'OC1383119082116028', '136190821152157', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '1', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(139, '139442008213213', '1102008213213', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(140, '1401520082132333', '31520082132333', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(141, '141120082153238', '17320082153238', '-', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(142, '142420082153319', '17420082153319', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(143, '143192008215342', '17172008215342', '-', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(144, '144520082153619', '5520082153619', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(145, '1451120082153751', '5220082153751', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(146, '1465920082153812', '75920082153812', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(147, '1471420082154015', '71420082154015', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(148, '148020082154659', '15520082154659', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(149, '1491820082155957', '32920082155957', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(150, '15015200821629', '315200821629', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(151, '151762008216318', '7762008216318', '-', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(152, '15212008216521', '7212008216521', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(153, '15362008216529', '762008216529', '101', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(154, '15402008216553', '702008216553', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(155, '155392008216656', '9392008216656', '103', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(156, '1561120082161049', '111120082161049', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(157, '1571520082161129', '131520082161129', '102', '0.00', '0.00', '0.00', '2021-08-16 00:00:00', '0', '', '', '', '', '', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(158, '1583120082174213', '13120082174213', '101', '0.00', '0.00', '0.00', '2021-08-17 00:00:00', '0', '', '', '', '', '', '2021-08-17 00:00:00', '', '2021-08-17 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(159, 'OC159912008217437', '111120082161049', '102', '0.00', '0.00', '0.00', '2021-08-17 00:00:00', '1', '', '', '', '', '', '2021-08-17 00:00:00', '', '2021-08-17 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(160, 'OC1601520082174420', '702008216553', '103', '0.00', '0.00', '0.00', '2021-08-18 00:00:00', '1', '', '', '', '', '', '2021-08-18 00:00:00', '', '2021-08-18 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(161, 'OC161620082174638', '1620082174638', '102', '0.00', '0.00', '0.00', '2021-08-18 00:00:00', '1', '', '', '', '', '', '2021-08-18 00:00:00', '', '2021-08-18 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(162, '1623220082175220', '13220082175219', '101', '0.00', '0.00', '0.00', '2021-08-18 00:00:00', '0', '', '', '', '', '', '2021-08-18 00:00:00', '', '2021-08-18 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(163, 'OC1631720082175230', '13220082175219', '101', '0.00', '0.00', '0.00', '2021-08-18 00:00:00', '1', '', '', '', '', '', '2021-08-18 00:00:00', '', '2021-08-18 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(164, '164320082175952', '1320082175952', '103', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '0', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(165, 'OC1657200821805', '1320082175952', '103', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '1', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(166, '166232008218154', '1232008218154', '102', '0.00', '0.00', '0.00', '2021-08-19 00:00:00', '0', '', '', '', '', '', '2021-08-19 00:00:00', '', '2021-08-19 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(167, '1673820082120110', '11320082120110', '102', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '0', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(168, 'OC168272108215316', '3272108215315', '104', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '1', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(169, '1691421082111512', '11921082111512', '103', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '0', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(170, '1700210821125421', '10210821125421', '102', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '0', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(171, '1713121082113044', '13121082113044', '103', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '0', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(172, 'OC17252210821131853', '152210821131853', '104', '0.00', '0.00', '0.00', '2021-08-20 00:00:00', '1', '', '', '', '', '', '2021-08-20 00:00:00', '', '2021-08-20 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(173, 'OC1736221082116462', '16221082116462', '102', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(174, 'OC17418210821164918', '16210821164918', '103', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(175, 'OC175921082116515', '1921082116515', '104', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(176, 'OC17616210821165815', '117210821165815', '105', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(177, 'OC177422082141622', '14622082141621', '106', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(178, 'OC178482208214179', '1482208214179', '101', '0.00', '0.00', '0.00', '2021-08-22 00:00:00', '1', '', '', '', '', '', '2021-08-22 00:00:00', '', '2021-08-22 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(179, 'OC1793622082153634', '16221082116462', '102', '0.00', '0.00', '0.00', '2021-08-23 00:00:00', '0', '', '', '', '', '', '2021-08-23 00:00:00', '', '2021-08-23 00:00:00', '', '', '', '', '1351808216575', '151130821175930', 'chambre'),
(180, 'OC18050220821175332', '150220821175332', '103', '0.00', '0.00', '0.00', '2021-08-24 00:00:00', '1', '', '', '', '', '', '2021-08-24 00:00:00', '', '2021-08-24 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(181, '18147220821175445', '147220821175445', '103', '0.00', '0.00', '0.00', '2021-08-24 00:00:00', '0', '', '', '', '', '', '2021-08-24 00:00:00', '', '2021-08-24 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(182, 'OC1822523082173956', '1023082173956', '106', '0.00', '0.00', '0.00', '2021-08-23 00:00:00', '1', '', '', '', '', '', '2021-08-23 00:00:00', '', '2021-08-23 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(183, 'OC183112308218936', '1112308218936', '107', '0.00', '0.00', '0.00', '2021-08-24 00:00:00', '1', '', '', '', '', '', '2021-08-24 00:00:00', '', '2021-08-24 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(184, '1846223082118498', '13523082118498', '107', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '0', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(185, '1854240821174919', '14240821174919', '102', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '0', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(186, 'OC18625240821174939', '14240821174919', '102', '0.00', '0.00', '0.00', '2021-08-25 00:00:00', '1', '', '', '', '', '', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(187, '187125082115958', '1825082115958', '108', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '0', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(188, '18811250821151134', '111250821151134', '101', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '0', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(189, '1899250821152750', '124250821152750', '107', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '0', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(190, '19040250821155333', '140250821155333', '109', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '0', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre'),
(191, '1911925082116115', '15325082116115', '103', '0.00', '0.00', '0.00', '2021-08-26 00:00:00', '0', '', '', '', '', '', '2021-08-26 00:00:00', '', '2021-08-26 00:00:00', '', '', '', '', '', '151130821175930', 'chambre');

-- --------------------------------------------------------

--
-- Table structure for table `pays`
--

CREATE TABLE `pays` (
  `ID_PAYS` int(11) NOT NULL,
  `NOM_PAYS` varchar(80) NOT NULL,
  `nicename` varchar(80) NOT NULL,
  `iso3` char(3) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pays`
--

INSERT INTO `pays` (`ID_PAYS`, `NOM_PAYS`, `nicename`, `iso3`) VALUES
(1, 'AFGHANISTAN', 'Afghanistan', 'AFG'),
(2, 'ALBANIA', 'Albania', 'ALB'),
(3, 'ALGERIA', 'Algeria', 'DZA'),
(4, 'AMERICAN SAMOA', 'American Samoa', 'ASM'),
(5, 'ANDORRA', 'Andorra', 'AND'),
(6, 'ANGOLA', 'Angola', 'AGO'),
(7, 'ANGUILLA', 'Anguilla', 'AIA'),
(8, 'ANTARCTICA', 'Antarctica', NULL),
(9, 'ANTIGUA AND BARBUDA', 'Antigua and Barbuda', 'ATG'),
(10, 'ARGENTINA', 'Argentina', 'ARG'),
(11, 'ARMENIA', 'Armenia', 'ARM'),
(12, 'ARUBA', 'Aruba', 'ABW'),
(13, 'AUSTRALIA', 'Australia', 'AUS'),
(14, 'AUSTRIA', 'Austria', 'AUT'),
(15, 'AZERBAIJAN', 'Azerbaijan', 'AZE'),
(16, 'BAHAMAS', 'Bahamas', 'BHS'),
(17, 'BAHRAIN', 'Bahrain', 'BHR'),
(18, 'BANGLADESH', 'Bangladesh', 'BGD'),
(19, 'BARBADOS', 'Barbados', 'BRB'),
(20, 'BELARUS', 'Belarus', 'BLR'),
(21, 'BELGIUM', 'Belgium', 'BEL'),
(22, 'BELIZE', 'Belize', 'BLZ'),
(23, 'BENIN', 'Benin', 'BEN'),
(24, 'BERMUDA', 'Bermuda', 'BMU'),
(25, 'BHUTAN', 'Bhutan', 'BTN'),
(26, 'BOLIVIA', 'Bolivia', 'BOL'),
(27, 'BOSNIA AND HERZEGOVINA', 'Bosnia and Herzegovina', 'BIH'),
(28, 'BOTSWANA', 'Botswana', 'BWA'),
(29, 'BOUVET ISLAND', 'Bouvet Island', NULL),
(30, 'BRAZIL', 'Brazil', 'BRA'),
(31, 'BRITISH INDIAN OCEAN TERRITORY', 'British Indian Ocean Territory', NULL),
(32, 'BRUNEI DARUSSALAM', 'Brunei Darussalam', 'BRN'),
(33, 'BULGARIA', 'Bulgaria', 'BGR'),
(34, 'BURKINA FASO', 'Burkina Faso', 'BFA'),
(35, 'BURUNDI', 'Burundi', 'BDI'),
(36, 'CAMBODIA', 'Cambodia', 'KHM'),
(37, 'CAMEROON', 'Cameroon', 'CMR'),
(38, 'CANADA', 'Canada', 'CAN'),
(39, 'CAPE VERDE', 'Cape Verde', 'CPV'),
(40, 'CAYMAN ISLANDS', 'Cayman Islands', 'CYM'),
(41, 'CENTRAL AFRICAN REPUBLIC', 'Central African Republic', 'CAF'),
(42, 'CHAD', 'Chad', 'TCD'),
(43, 'CHILE', 'Chile', 'CHL'),
(44, 'CHINA', 'China', 'CHN'),
(45, 'CHRISTMAS ISLAND', 'Christmas Island', NULL),
(46, 'COCOS (KEELING) ISLANDS', 'Cocos (Keeling) Islands', NULL),
(47, 'COLOMBIA', 'Colombia', 'COL'),
(48, 'COMOROS', 'Comoros', 'COM'),
(49, 'CONGO', 'Congo', 'COG'),
(50, 'CONGO, THE DEMOCRATIC REPUBLIC OF THE', 'Congo, the Democratic Republic of the', 'COD'),
(51, 'COOK ISLANDS', 'Cook Islands', 'COK'),
(52, 'COSTA RICA', 'Costa Rica', 'CRI'),
(53, 'COTE D\'IVOIRE', 'Cote D\'Ivoire', 'CIV'),
(54, 'CROATIA', 'Croatia', 'HRV'),
(55, 'CUBA', 'Cuba', 'CUB'),
(56, 'CYPRUS', 'Cyprus', 'CYP'),
(57, 'CZECH REPUBLIC', 'Czech Republic', 'CZE'),
(58, 'DENMARK', 'Denmark', 'DNK'),
(59, 'DJIBOUTI', 'Djibouti', 'DJI'),
(60, 'DOMINICA', 'Dominica', 'DMA'),
(61, 'DOMINICAN REPUBLIC', 'Dominican Republic', 'DOM'),
(62, 'ECUADOR', 'Ecuador', 'ECU'),
(63, 'EGYPT', 'Egypt', 'EGY'),
(64, 'EL SALVADOR', 'El Salvador', 'SLV'),
(65, 'EQUATORIAL GUINEA', 'Equatorial Guinea', 'GNQ'),
(66, 'ERITREA', 'Eritrea', 'ERI'),
(67, 'ESTONIA', 'Estonia', 'EST'),
(68, 'ETHIOPIA', 'Ethiopia', 'ETH'),
(69, 'FALKLAND ISLANDS (MALVINAS)', 'Falkland Islands (Malvinas)', 'FLK'),
(70, 'FAROE ISLANDS', 'Faroe Islands', 'FRO'),
(71, 'FIJI', 'Fiji', 'FJI'),
(72, 'FINLAND', 'Finland', 'FIN'),
(73, 'FRANCE', 'France', 'FRA'),
(74, 'FRENCH GUIANA', 'French Guiana', 'GUF'),
(75, 'FRENCH POLYNESIA', 'French Polynesia', 'PYF'),
(76, 'FRENCH SOUTHERN TERRITORIES', 'French Southern Territories', NULL),
(77, 'GABON', 'Gabon', 'GAB'),
(78, 'GAMBIA', 'Gambia', 'GMB'),
(79, 'GEORGIA', 'Georgia', 'GEO'),
(80, 'GERMANY', 'Germany', 'DEU'),
(81, 'GHANA', 'Ghana', 'GHA'),
(82, 'GIBRALTAR', 'Gibraltar', 'GIB'),
(83, 'GREECE', 'Greece', 'GRC'),
(84, 'GREENLAND', 'Greenland', 'GRL'),
(85, 'GRENADA', 'Grenada', 'GRD'),
(86, 'GUADELOUPE', 'Guadeloupe', 'GLP'),
(87, 'GUAM', 'Guam', 'GUM'),
(88, 'GUATEMALA', 'Guatemala', 'GTM'),
(89, 'GUINEA', 'Guinea', 'GIN'),
(90, 'GUINEA-BISSAU', 'Guinea-Bissau', 'GNB'),
(91, 'GUYANA', 'Guyana', 'GUY'),
(92, 'HAITI', 'Haiti', 'HTI'),
(93, 'HEARD ISLAND AND MCDONALD ISLANDS', 'Heard Island and Mcdonald Islands', NULL),
(94, 'HOLY SEE (VATICAN CITY STATE)', 'Holy See (Vatican City State)', 'VAT'),
(95, 'HONDURAS', 'Honduras', 'HND'),
(96, 'HONG KONG', 'Hong Kong', 'HKG'),
(97, 'HUNGARY', 'Hungary', 'HUN'),
(98, 'ICELAND', 'Iceland', 'ISL'),
(99, 'INDIA', 'India', 'IND'),
(100, 'INDONESIA', 'Indonesia', 'IDN'),
(101, 'IRAN, ISLAMIC REPUBLIC OF', 'Iran, Islamic Republic of', 'IRN'),
(102, 'IRAQ', 'Iraq', 'IRQ'),
(103, 'IRELAND', 'Ireland', 'IRL'),
(104, 'ISRAEL', 'Israel', 'ISR'),
(105, 'ITALY', 'Italy', 'ITA'),
(106, 'JAMAICA', 'Jamaica', 'JAM'),
(107, 'JAPAN', 'Japan', 'JPN'),
(108, 'JORDAN', 'Jordan', 'JOR'),
(109, 'KAZAKHSTAN', 'Kazakhstan', 'KAZ'),
(110, 'KENYA', 'Kenya', 'KEN'),
(111, 'KIRIBATI', 'Kiribati', 'KIR'),
(112, 'KOREA, DEMOCRATIC PEOPLE\'S REPUBLIC OF', 'Korea, Democratic People\'s Republic of', 'PRK'),
(113, 'KOREA, REPUBLIC OF', 'Korea, Republic of', 'KOR'),
(114, 'KUWAIT', 'Kuwait', 'KWT'),
(115, 'KYRGYZSTAN', 'Kyrgyzstan', 'KGZ'),
(116, 'LAO PEOPLE\'S DEMOCRATIC REPUBLIC', 'Lao People\'s Democratic Republic', 'LAO'),
(117, 'LATVIA', 'Latvia', 'LVA'),
(118, 'LEBANON', 'Lebanon', 'LBN'),
(119, 'LESOTHO', 'Lesotho', 'LSO'),
(120, 'LIBERIA', 'Liberia', 'LBR'),
(121, 'LIBYAN ARAB JAMAHIRIYA', 'Libyan Arab Jamahiriya', 'LBY'),
(122, 'LIECHTENSTEIN', 'Liechtenstein', 'LIE'),
(123, 'LITHUANIA', 'Lithuania', 'LTU'),
(124, 'LUXEMBOURG', 'Luxembourg', 'LUX'),
(125, 'MACAO', 'Macao', 'MAC'),
(126, 'MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF', 'Macedonia, the Former Yugoslav Republic of', 'MKD'),
(127, 'MADAGASCAR', 'Madagascar', 'MDG'),
(128, 'MALAWI', 'Malawi', 'MWI'),
(129, 'MALAYSIA', 'Malaysia', 'MYS'),
(130, 'MALDIVES', 'Maldives', 'MDV'),
(131, 'MALI', 'Mali', 'MLI'),
(132, 'MALTA', 'Malta', 'MLT'),
(133, 'MARSHALL ISLANDS', 'Marshall Islands', 'MHL'),
(134, 'MARTINIQUE', 'Martinique', 'MTQ'),
(135, 'MAURITANIA', 'Mauritania', 'MRT'),
(136, 'MAURITIUS', 'Mauritius', 'MUS'),
(137, 'MAYOTTE', 'Mayotte', NULL),
(138, 'MEXICO', 'Mexico', 'MEX'),
(139, 'MICRONESIA, FEDERATED STATES OF', 'Micronesia, Federated States of', 'FSM'),
(140, 'MOLDOVA, REPUBLIC OF', 'Moldova, Republic of', 'MDA'),
(141, 'MONACO', 'Monaco', 'MCO'),
(142, 'MONGOLIA', 'Mongolia', 'MNG'),
(143, 'MONTSERRAT', 'Montserrat', 'MSR'),
(144, 'MOROCCO', 'Morocco', 'MAR'),
(145, 'MOZAMBIQUE', 'Mozambique', 'MOZ'),
(146, 'MYANMAR', 'Myanmar', 'MMR'),
(147, 'NAMIBIA', 'Namibia', 'NAM'),
(148, 'NAURU', 'Nauru', 'NRU'),
(149, 'NEPAL', 'Nepal', 'NPL'),
(150, 'NETHERLANDS', 'Netherlands', 'NLD'),
(151, 'NETHERLANDS ANTILLES', 'Netherlands Antilles', 'ANT'),
(152, 'NEW CALEDONIA', 'New Caledonia', 'NCL'),
(153, 'NEW ZEALAND', 'New Zealand', 'NZL'),
(154, 'NICARAGUA', 'Nicaragua', 'NIC'),
(155, 'NIGER', 'Niger', 'NER'),
(156, 'NIGERIA', 'Nigeria', 'NGA'),
(157, 'NIUE', 'Niue', 'NIU'),
(158, 'NORFOLK ISLAND', 'Norfolk Island', 'NFK'),
(159, 'NORTHERN MARIANA ISLANDS', 'Northern Mariana Islands', 'MNP'),
(160, 'NORWAY', 'Norway', 'NOR'),
(161, 'OMAN', 'Oman', 'OMN'),
(162, 'PAKISTAN', 'Pakistan', 'PAK'),
(163, 'PALAU', 'Palau', 'PLW'),
(164, 'PALESTINIAN TERRITORY, OCCUPIED', 'Palestinian Territory, Occupied', NULL),
(165, 'PANAMA', 'Panama', 'PAN'),
(166, 'PAPUA NEW GUINEA', 'Papua New Guinea', 'PNG'),
(167, 'PARAGUAY', 'Paraguay', 'PRY'),
(168, 'PERU', 'Peru', 'PER'),
(169, 'PHILIPPINES', 'Philippines', 'PHL'),
(170, 'PITCAIRN', 'Pitcairn', 'PCN'),
(171, 'POLAND', 'Poland', 'POL'),
(172, 'PORTUGAL', 'Portugal', 'PRT'),
(173, 'PUERTO RICO', 'Puerto Rico', 'PRI'),
(174, 'QATAR', 'Qatar', 'QAT'),
(175, 'REUNION', 'Reunion', 'REU'),
(176, 'ROMANIA', 'Romania', 'ROM'),
(177, 'RUSSIAN FEDERATION', 'Russian Federation', 'RUS'),
(178, 'RWANDA', 'Rwanda', 'RWA'),
(179, 'SAINT HELENA', 'Saint Helena', 'SHN'),
(180, 'SAINT KITTS AND NEVIS', 'Saint Kitts and Nevis', 'KNA'),
(181, 'SAINT LUCIA', 'Saint Lucia', 'LCA'),
(182, 'SAINT PIERRE AND MIQUELON', 'Saint Pierre and Miquelon', 'SPM'),
(183, 'SAINT VINCENT AND THE GRENADINES', 'Saint Vincent and the Grenadines', 'VCT'),
(184, 'SAMOA', 'Samoa', 'WSM'),
(185, 'SAN MARINO', 'San Marino', 'SMR'),
(186, 'SAO TOME AND PRINCIPE', 'Sao Tome and Principe', 'STP'),
(187, 'SAUDI ARABIA', 'Saudi Arabia', 'SAU'),
(188, 'SENEGAL', 'Senegal', 'SEN'),
(189, 'SERBIA AND MONTENEGRO', 'Serbia and Montenegro', NULL),
(190, 'SEYCHELLES', 'Seychelles', 'SYC'),
(191, 'SIERRA LEONE', 'Sierra Leone', 'SLE'),
(192, 'SINGAPORE', 'Singapore', 'SGP'),
(193, 'SLOVAKIA', 'Slovakia', 'SVK'),
(194, 'SLOVENIA', 'Slovenia', 'SVN'),
(195, 'SOLOMON ISLANDS', 'Solomon Islands', 'SLB'),
(196, 'SOMALIA', 'Somalia', 'SOM'),
(197, 'SOUTH AFRICA', 'South Africa', 'ZAF'),
(198, 'SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS', 'South Georgia and the South Sandwich Islands', NULL),
(199, 'SPAIN', 'Spain', 'ESP'),
(200, 'SRI LANKA', 'Sri Lanka', 'LKA'),
(201, 'SUDAN', 'Sudan', 'SDN'),
(202, 'SURINAME', 'Suriname', 'SUR'),
(203, 'SVALBARD AND JAN MAYEN', 'Svalbard and Jan Mayen', 'SJM'),
(204, 'SWAZILAND', 'Swaziland', 'SWZ'),
(205, 'SWEDEN', 'Sweden', 'SWE'),
(206, 'SWITZERLAND', 'Switzerland', 'CHE'),
(207, 'SYRIAN ARAB REPUBLIC', 'Syrian Arab Republic', 'SYR'),
(208, 'TAIWAN, PROVINCE OF CHINA', 'Taiwan, Province of China', 'TWN'),
(209, 'TAJIKISTAN', 'Tajikistan', 'TJK'),
(210, 'TANZANIA, UNITED REPUBLIC OF', 'Tanzania, United Republic of', 'TZA'),
(211, 'THAILAND', 'Thailand', 'THA'),
(212, 'TIMOR-LESTE', 'Timor-Leste', NULL),
(213, 'TOGO', 'Togo', 'TGO'),
(214, 'TOKELAU', 'Tokelau', 'TKL'),
(215, 'TONGA', 'Tonga', 'TON'),
(216, 'TRINIDAD AND TOBAGO', 'Trinidad and Tobago', 'TTO'),
(217, 'TUNISIA', 'Tunisia', 'TUN'),
(218, 'TURKEY', 'Turkey', 'TUR'),
(219, 'TURKMENISTAN', 'Turkmenistan', 'TKM'),
(220, 'TURKS AND CAICOS ISLANDS', 'Turks and Caicos Islands', 'TCA'),
(221, 'TUVALU', 'Tuvalu', 'TUV'),
(222, 'UGANDA', 'Uganda', 'UGA'),
(223, 'UKRAINE', 'Ukraine', 'UKR'),
(224, 'UNITED ARAB EMIRATES', 'United Arab Emirates', 'ARE'),
(225, 'UNITED KINGDOM', 'United Kingdom', 'GBR'),
(226, 'UNITED STATES', 'United States', 'USA'),
(227, 'UNITED STATES MINOR OUTLYING ISLANDS', 'United States Minor Outlying Islands', NULL),
(228, 'URUGUAY', 'Uruguay', 'URY'),
(229, 'UZBEKISTAN', 'Uzbekistan', 'UZB'),
(230, 'VANUATU', 'Vanuatu', 'VUT'),
(231, 'VENEZUELA', 'Venezuela', 'VEN'),
(232, 'VIET NAM', 'Viet Nam', 'VNM'),
(233, 'VIRGIN ISLANDS, BRITISH', 'Virgin Islands, British', 'VGB'),
(234, 'VIRGIN ISLANDS, U.S.', 'Virgin Islands, U.s.', 'VIR'),
(235, 'WALLIS AND FUTUNA', 'Wallis and Futuna', 'WLF'),
(236, 'WESTERN SAHARA', 'Western Sahara', 'ESH'),
(237, 'YEMEN', 'Yemen', 'YEM'),
(238, 'ZAMBIA', 'Zambia', 'ZMB'),
(239, 'ZIMBABWE', 'Zimbabwe', 'ZWE');

-- --------------------------------------------------------

--
-- Table structure for table `personnel`
--

CREATE TABLE `personnel` (
  `ID_PERSONNEL` int(11) NOT NULL,
  `CODE_PERSONNEL` varchar(30) DEFAULT NULL,
  `MATRICULE` varchar(30) DEFAULT NULL,
  `NOM_PERSONNEL` varchar(50) DEFAULT NULL,
  `NOM_JEUNE_FILLE` varchar(50) DEFAULT NULL,
  `PRENOM_PERSONNEL` varchar(50) DEFAULT NULL,
  `DATE_NAISSANCE` date DEFAULT NULL,
  `LIEU_NAISSANCE` varchar(50) DEFAULT NULL,
  `NOM_PERE` varchar(50) DEFAULT NULL,
  `NOM_MERE` varchar(50) DEFAULT NULL,
  `PROFESSION` varchar(50) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `SEXE` varchar(10) DEFAULT NULL,
  `NUMERO_CNI` varchar(50) DEFAULT NULL,
  `CODE_TYPE_PERSONNEL` varchar(30) DEFAULT NULL,
  `ADRESSE` varchar(50) DEFAULT NULL,
  `TELEPHONE` varchar(15) DEFAULT NULL,
  `FAX` varchar(10) DEFAULT NULL,
  `EMAIL` varchar(50) DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `DATE_CREATION` datetime DEFAULT CURRENT_TIMESTAMP,
  `CHEMIN_PHOTO` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `planning`
--

CREATE TABLE `planning` (
  `ID_PLANNING` int(11) NOT NULL,
  `CODE_PLANNING` varchar(30) NOT NULL,
  `CODE_RESERVATION` varchar(30) NOT NULL,
  `CODE_CHAMBRE` varchar(30) NOT NULL,
  `NOM_PRENOM` varchar(100) NOT NULL,
  `DATE_ARRIVEE` date NOT NULL,
  `DATE_DEPART` date NOT NULL,
  `CODE_CLIENT` varchar(30) NOT NULL,
  `FIRST_CELL_ROW` int(11) NOT NULL,
  `FIRST_CELL_COLUMN` int(11) NOT NULL,
  `SECOND_CELL_ROW` int(11) NOT NULL,
  `SECOND_CELL_COLUMN` int(11) NOT NULL,
  `CODE_AGENCE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `planning_hebdomadaire`
--

CREATE TABLE `planning_hebdomadaire` (
  `ID_PLANNING_HEBDOMADAIRE` int(11) NOT NULL,
  `CODE_PLANNING` varchar(30) NOT NULL,
  `DATE_DEBUT` date DEFAULT NULL,
  `HEURE_DEBUT` time NOT NULL,
  `CODE_PERSONNEL` varchar(30) DEFAULT NULL,
  `DATE_CREATION` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CODE_AGENCE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `planning_hebdomadaire`
--

INSERT INTO `planning_hebdomadaire` (`ID_PLANNING_HEBDOMADAIRE`, `CODE_PLANNING`, `DATE_DEBUT`, `HEURE_DEBUT`, `CODE_PERSONNEL`, `DATE_CREATION`, `CODE_AGENCE`) VALUES
(16, '12104082193636', '2021-08-04', '23:50:00', '11803082118040', '2021-08-04 09:36:36', 'AG228362507211543'),
(17, '222040821101852', '2021-08-05', '23:50:00', '241030821234135', '2021-08-04 10:18:52', 'AG228362507211543'),
(18, '222040821101852', '2021-08-05', '23:50:00', '38030821234222', '2021-08-04 10:18:52', 'AG228362507211543'),
(19, '461040821101914', '2021-08-06', '23:50:00', '241030821234135', '2021-08-04 10:19:14', 'AG228362507211543'),
(20, '461040821101914', '2021-08-06', '23:50:00', '38030821234222', '2021-08-04 10:19:14', 'AG228362507211543'),
(21, '654040821101925', '2021-08-07', '23:50:00', '241030821234135', '2021-08-04 10:19:25', 'AG228362507211543'),
(22, '654040821101925', '2021-08-07', '23:50:00', '38030821234222', '2021-08-04 10:19:26', 'AG228362507211543'),
(23, '89040821102119', '2021-08-09', '23:50:00', '241030821234135', '2021-08-04 10:21:19', 'AG228362507211543'),
(24, '94040821103448', '2021-08-11', '23:50:00', '11803082118040', '2021-08-04 10:34:48', 'AG228362507211543'),
(25, '101005082116931', '2021-08-12', '23:50:00', '38030821234222', '2021-08-05 16:09:31', 'AG270508212200'),
(26, '101005082116931', '2021-08-12', '23:50:00', '11803082118040', '2021-08-05 16:09:31', 'AG270508212200'),
(27, '101005082116931', '2021-08-12', '23:50:00', '241030821234135', '2021-08-05 16:09:31', 'AG270508212200');

-- --------------------------------------------------------

--
-- Table structure for table `reglement`
--

CREATE TABLE `reglement` (
  `ID_REGLEMENT` int(20) NOT NULL,
  `NUM_REGLEMENT` varchar(30) DEFAULT NULL,
  `NUM_FACTURE` varchar(30) DEFAULT NULL,
  `CODE_CAISSIER` varchar(30) DEFAULT NULL,
  `MONTANT_VERSE` decimal(17,2) DEFAULT NULL,
  `DATE_REGLEMENT` datetime DEFAULT NULL,
  `MODE_REGLEMENT` varchar(30) DEFAULT NULL,
  `REF_REGLEMENT` varchar(60) DEFAULT NULL,
  `CODE_MODE` varchar(10) DEFAULT NULL,
  `IMPRIMER` double DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL,
  `CODE_RESERVATION` varchar(30) NOT NULL,
  `CODE_CLIENT` varchar(30) NOT NULL,
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre',
  `QUANTITE` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reglement`
--

INSERT INTO `reglement` (`ID_REGLEMENT`, `NUM_REGLEMENT`, `NUM_FACTURE`, `CODE_CAISSIER`, `MONTANT_VERSE`, `DATE_REGLEMENT`, `MODE_REGLEMENT`, `REF_REGLEMENT`, `CODE_MODE`, `IMPRIMER`, `CODE_AGENCE`, `CODE_RESERVATION`, `CODE_CLIENT`, `TYPE`, `QUANTITE`) VALUES
(1, '1723082191450', '1351808216575', '', '105750.00', '2021-08-23 00:00:00', 'Espèce', 'REGLEMENT KAMDEM KAMDEM  23/08/2021 09:14:35', '', 0, '151130821175930', '1112308218936', '1351808216575', 'chambre', 1),
(2, '274230821103246', '1351808216575', '', '2500.00', '2021-08-23 00:00:00', 'Espèce', 'REBOURSEMENT KAMDEM KAMDEM  23/08/2021 10:32:37', '', 0, '151130821175930', '1112308218936', '1351808216575', 'chambre', 1),
(3, '32230821104045', '1351808216575', '', '2500.00', '2021-08-23 00:00:00', 'Espèce', 'REBOURSEMENT KAMDEM KAMDEM  23/08/2021 10:40:36', '', 0, '151130821175930', '1112308218936', '1351808216575', 'chambre', 1);

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `ID_RESERVATION` int(11) NOT NULL,
  `CODE_RESERVATION` varchar(30) NOT NULL,
  `CLIENT_ID` varchar(30) NOT NULL,
  `UTILISATEUR_ID` varchar(30) NOT NULL,
  `CHAMBRE_ID` varchar(30) NOT NULL,
  `AGENCE_ID` varchar(30) NOT NULL,
  `NOM_CLIENT` varchar(100) NOT NULL,
  `DATE_ENTTRE` date NOT NULL,
  `HEURE_ENTREE` varchar(30) NOT NULL,
  `DATE_SORTIE` date NOT NULL,
  `HEURE_SORTIE` varchar(30) NOT NULL,
  `ADULTES` int(10) NOT NULL,
  `NB_PERSONNES` int(10) NOT NULL,
  `ENFANTS` int(10) NOT NULL,
  `RECEVOIR_EMAIL` int(10) NOT NULL,
  `RECEVOIR_SMS` int(10) NOT NULL,
  `ETAT_RESERVATION` int(10) DEFAULT '0',
  `DATE_CREATION` date NOT NULL,
  `HEURE_CREATION` varchar(30) NOT NULL,
  `MONTANT_TOTAL_CAUTION` double NOT NULL,
  `MOTIF_ETAT` varchar(100) NOT NULL,
  `DATE_ETAT` date NOT NULL,
  `MONTANT_ACCORDE` double NOT NULL,
  `GROUPE` varchar(10) NOT NULL,
  `CHECKIN` varchar(3) NOT NULL DEFAULT 'NON',
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre',
  `PETIT_DEJEUNER` double NOT NULL,
  `SOLDE_RESERVATION` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reservation`
--

INSERT INTO `reservation` (`ID_RESERVATION`, `CODE_RESERVATION`, `CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `CHECKIN`, `TYPE`, `PETIT_DEJEUNER`, `SOLDE_RESERVATION`) VALUES
(1, '15325082116115', '1351808216575', '', '103', '151130821175930', 'KAMDEM KAMDEM', '2021-08-26', '01/01/0001 12:00:00', '2021-08-28', '01/01/0001 12:00:00', 1, 1, 0, 0, 0, 0, '2021-08-26', '01/01/0001 04:11:05', 0, '', '2021-08-26', 35000, '', 'NON', 'chambre', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `reserve_conf`
--

CREATE TABLE `reserve_conf` (
  `ID_RESERVATION` int(11) NOT NULL,
  `CODE_RESERVATION` varchar(30) NOT NULL,
  `CLIENT_ID` varchar(30) NOT NULL,
  `UTILISATEUR_ID` varchar(30) NOT NULL,
  `CHAMBRE_ID` varchar(30) NOT NULL,
  `AGENCE_ID` varchar(30) NOT NULL,
  `NOM_CLIENT` varchar(100) NOT NULL,
  `DATE_ENTTRE` date NOT NULL,
  `HEURE_ENTREE` varchar(30) NOT NULL,
  `DATE_SORTIE` date NOT NULL,
  `HEURE_SORTIE` varchar(30) NOT NULL,
  `ADULTES` int(10) NOT NULL,
  `NB_PERSONNES` int(10) NOT NULL,
  `ENFANTS` int(10) NOT NULL,
  `RECEVOIR_EMAIL` int(10) NOT NULL,
  `RECEVOIR_SMS` int(10) NOT NULL,
  `ETAT_RESERVATION` int(10) NOT NULL DEFAULT '1',
  `DATE_CREATION` date NOT NULL,
  `HEURE_CREATION` varchar(30) NOT NULL,
  `MONTANT_TOTAL_CAUTION` double NOT NULL,
  `MOTIF_ETAT` varchar(100) NOT NULL,
  `DATE_ETAT` date NOT NULL,
  `MONTANT_ACCORDE` double NOT NULL,
  `GROUPE` varchar(10) NOT NULL,
  `CHECKIN` varchar(3) NOT NULL DEFAULT 'OUI',
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre',
  `PETIT_DEJEUNER` double NOT NULL,
  `SOLDE_RESERVATION` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reserve_conf`
--

INSERT INTO `reserve_conf` (`ID_RESERVATION`, `CODE_RESERVATION`, `CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `CHECKIN`, `TYPE`, `PETIT_DEJEUNER`, `SOLDE_RESERVATION`) VALUES
(25, '1112308218936', '1351808216575', '', '107', '151130821175930', 'KAMDEM KAMDEM ', '2021-08-24', '0001-01-01 12:00:00', '2021-08-27', '0001-01-01 12:00:00', 1, 1, 0, 0, 0, 1, '2021-08-25', '0001-01-01 06:49:08', 0, '', '2021-08-25', 35000, '', 'OUI', 'chambre', 0, -30000),
(26, '14240821174919', '1351808216575', '', '102', '151130821175930', 'KAMDEM KAMDEM ', '2021-08-25', '0001-01-01 12:00:00', '2021-08-26', '0001-01-01 12:00:00', 1, 1, 0, 0, 0, 1, '2021-08-25', '0001-01-01 05:49:39', 0, '', '2021-08-25', 15000, '', 'OUI', 'chambre', 0, -15000);

-- --------------------------------------------------------

--
-- Table structure for table `reserve_temp`
--

CREATE TABLE `reserve_temp` (
  `ID_RESERVATION` int(11) NOT NULL,
  `CODE_RESERVATION` varchar(30) NOT NULL,
  `CLIENT_ID` varchar(30) NOT NULL,
  `UTILISATEUR_ID` varchar(30) NOT NULL,
  `CHAMBRE_ID` varchar(30) NOT NULL,
  `AGENCE_ID` varchar(30) NOT NULL,
  `NOM_CLIENT` varchar(100) NOT NULL,
  `DATE_ENTTRE` date NOT NULL,
  `HEURE_ENTREE` varchar(30) NOT NULL,
  `DATE_SORTIE` date NOT NULL,
  `HEURE_SORTIE` varchar(30) NOT NULL,
  `ADULTES` int(10) NOT NULL,
  `NB_PERSONNES` int(10) NOT NULL,
  `ENFANTS` int(10) NOT NULL,
  `RECEVOIR_EMAIL` int(10) NOT NULL,
  `RECEVOIR_SMS` int(10) NOT NULL,
  `ETAT_RESERVATION` int(10) NOT NULL DEFAULT '1',
  `DATE_CREATION` date NOT NULL,
  `HEURE_CREATION` varchar(30) NOT NULL,
  `MONTANT_TOTAL_CAUTION` double NOT NULL,
  `MOTIF_ETAT` varchar(100) NOT NULL,
  `DATE_ETAT` date NOT NULL,
  `MONTANT_ACCORDE` double NOT NULL,
  `GROUPE` varchar(10) NOT NULL,
  `CHECKIN` varchar(3) NOT NULL DEFAULT 'OUI',
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre',
  `PETIT_DEJEUNER` double NOT NULL,
  `SOLDE_RESERVATION` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reserve_temp`
--

INSERT INTO `reserve_temp` (`ID_RESERVATION`, `CODE_RESERVATION`, `CLIENT_ID`, `UTILISATEUR_ID`, `CHAMBRE_ID`, `AGENCE_ID`, `NOM_CLIENT`, `DATE_ENTTRE`, `HEURE_ENTREE`, `DATE_SORTIE`, `HEURE_SORTIE`, `ADULTES`, `NB_PERSONNES`, `ENFANTS`, `RECEVOIR_EMAIL`, `RECEVOIR_SMS`, `ETAT_RESERVATION`, `DATE_CREATION`, `HEURE_CREATION`, `MONTANT_TOTAL_CAUTION`, `MOTIF_ETAT`, `DATE_ETAT`, `MONTANT_ACCORDE`, `GROUPE`, `CHECKIN`, `TYPE`, `PETIT_DEJEUNER`, `SOLDE_RESERVATION`) VALUES
(1, '16221082116462', '', '', '102', '151130821175930', 'KAMDEM KAMDEM ', '2021-08-22', '2021-06-14 00:00:00', '2021-08-23', '2021-06-14 00:00:00', 1, 1, 0, 0, 0, 2, '2021-08-23', '0001-01-01 05:36:34', 0, '', '2021-08-23', 15000, '', 'OUI', 'chambre', 0, -15000);

-- --------------------------------------------------------

--
-- Table structure for table `societe`
--

CREATE TABLE `societe` (
  `ID_SOCIETE` int(11) NOT NULL,
  `CODE_SOCIETE` varchar(30) NOT NULL,
  `RAISON_SOCIALE` varchar(60) NOT NULL,
  `VILLE` varchar(30) NOT NULL,
  `BOITE_POSTALE` varchar(11) NOT NULL,
  `PAYS` varchar(30) NOT NULL,
  `TELEPHONE` varchar(17) NOT NULL,
  `FAX` varchar(17) NOT NULL,
  `EMAIL` varchar(60) NOT NULL,
  `RUE` varchar(20) NOT NULL,
  `NUM_CONTRIBUABLE` varchar(30) NOT NULL,
  `NUM_REGISTRE` varchar(60) NOT NULL,
  `TAUX_CHAMBRE` double NOT NULL,
  `TAUX_TVA` double NOT NULL,
  `TAUX_REPAS` double NOT NULL,
  `TAUX_PRODUIT` double NOT NULL,
  `CODE_MONNAIE` varchar(30) NOT NULL,
  `CODE_AGENCE_ACTUEL` varchar(30) NOT NULL,
  `DATE_CREATION` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LOGO` blob
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `societe`
--

INSERT INTO `societe` (`ID_SOCIETE`, `CODE_SOCIETE`, `RAISON_SOCIALE`, `VILLE`, `BOITE_POSTALE`, `PAYS`, `TELEPHONE`, `FAX`, `EMAIL`, `RUE`, `NUM_CONTRIBUABLE`, `NUM_REGISTRE`, `TAUX_CHAMBRE`, `TAUX_TVA`, `TAUX_REPAS`, `TAUX_PRODUIT`, `CODE_MONNAIE`, `CODE_AGENCE_ACTUEL`, `DATE_CREATION`, `LOGO`) VALUES
(25, '190130821175930', 'PRINCIPAUTE', 'YAOUNDE', '1458623', 'CAMEROUN', '693534844', '/', 'kamdemlandrygaetan@yahoo.fr', 'NSAM EFOULAN', 'NC456115454565454564564564', 'NR87987878787897DF', 0, 0, 0, 0, '', '151130821175930', '2021-08-15 00:00:00', 0x89504e470d0a1a0a0000000d49484452000001ae0000015808060000000b3e189e0000000467414d410000b18f0bfc6105000000097048597300002e2300002e230178a53f76000022fa49444154785eeddd7bf82d575ddf71434234702820419a340d260404b4621ad45011034d8182371452919a22355c1ec943f109a210841acaa5525a0235340f97e45191808d445442034f2c94861a09144953486393221609e6100e9c2a49483fdf0907f64c3ebff3db97ef9abd66d6fb8fd7fa639ff39b3597f59def9e3d33dff54db7df7e3b000093613f0400a056f64300006a653f0400a056f64300006a653f0400a056f64300006a653f0400a056f64300006a653f0400a056f64300006a653f0400a0565d739f438e035089619002e8eb1a173cc00a4e96670c3ec39a86410aa0af6b5cf0002b7897ec9713173ec39a86410aa0af6b5cf0004b7a90dc26b7cb75722f71ff0f4b1a062980beae71c1032ce97c89a475c0bbe51071ff174b18062980beae71c1032ce128899f0817135778b1b8ff8f250c8314405fd7b8e00196708e0c9356b8554e15f737d8c5304801f4758d0b1e60177b64afb8c4153e27c788fb5b1cc4304801f4758d0b1e6017cf1397b0167d480e17f7f7d8c1304801f4758d0b1ee0200e931bc425aba173c52d033b18062980beae71c1031cc44f8b4b523b79aab8e5c018062980beae71c1031cc455e212d44ebe240f15b72c0c0c8314405fd7b8e00176f05871c96937d7c83dc42d130b86410aa0af6b5cf0003b78afb8c4b48c77082f27ef6218a400fabac6050f60442d42979056f17c71cbc6d70c8314405fd7b8e0018cdf12978c56f11579a4b8e54386410aa0af6b5cf00003c7ca2de292d1aa3e23f713d74ff386410aa0af6b5cf00003af139784d675b91c2aaeafa60d8314405fd7b8e00116dc5bf6894b409b78b5b8fe9a360c52007d5de382075870b6b8c4b3a9afca93c4f5d9ac619002e8eb1a173cc0d71c217f212ef164f8823c505cdf4d1a062980beae71c1037ccd19e2124ea68fc9ddc4f5df9c619002e8eb1a173c80dc453e292ed964bb40dc3a346718a400fabac6050f203f262ec994f22c71ebd194619002e8eb1a173c805c212ec194f237f27071ebd28c619002e8eb1a173c68de0f884b2ea55d2ff711b74e4d18062980beae71c183e6bd4b5c6219c37b24eeafb9f59abd619002e8eb1a173c68da43e4367149652c2f15b76eb3370c52007d5de382074d3b5f5c3219d3adf27871eb376bc32005d0d7352e78d0aca3241e9270c9646c9f97fb8b5bcfd91a062980beae71c18366bd425c12d9962be57071eb3a4bc32005d0d7352e78d0a43db2575c02d9a6f3c4adef2c0d8314405fd7b8e0419362766297386af033e2d6797686410aa0af6b5cf0a03987c90de292460dbe2c0f13b7eeb3320c52007d5de38207cd892b1a97306af229b9a7b8f59f8d619002e8eb1a173c68ca21f25171c9a236174bacafdb8e5918062980beae71c183a63c4e5c92a8d50bc46dc72c0c8314405fd7b8e04153de272e41d42a5e4e7e94b86d99bc619002e8eb1a173c68c689e29243ed3e2b478bdba6491b062980beae71c18366bc5d5c6298820fca5dc56dd7640d8314405fd7b8e04113be5d6e119714a6e2b5e2b66db286410aa0af6b5cf0a009e78a4b0653f25579b2b8ed9ba4619002e8eb1a173c98bd98ac719fb864303537cb83c56de7e40c8314405fd7b8e0c1ec9d2d2e094cd5d5727771db3a29c32005d0d7352e78306b47c85f8a4b0053f636196eebe40c8314405fd7b8e0c1ac3d53dc897f0e9e2b6e9b276318a400fabac6050f66eb2e72adb893fe1cc42498278bdbf64918062980beae71c183d9fa097127fc39f9b4dc57dcf6576f18a400fabac6050f66eb0a7127fbb9b94c0e15b70faa360c52007d5de38207b314f5fddc497eae5e2e6e3f546d18a400fabac6050f66e9127127f8b98a97939f286e5f546b18a400fabac6050f66e7a112277277829fb39be43871fba44ac32005d0d7352e78303b6f1677626fc15512efaeb9fd529d619002e8eb1a173c9895a3241e137727f55644e276fba63ac32005d0d7352e78302baf1277326fcd33c4ed9faa0c8314405fd7b8e0c16cec91bde24ee4add92f3171a6db4fd518062980beae71c183d9384bdc49bc55d7c9bdc4edab2a0c8314405fd7b8e0c12c1c2e37883b81b7ecf7e51071fb6ceb86410aa0af6b5cf060164e1777e2c621c7bd58dc3edbba619002e8eb1a173c98bcb8a2f8b8b893360e39ee563955dcbedbaa619002e8eb1a173c98bcc7893b61e31b3e27c788db7f5b330c52007d5de382079377b9b89335fa3e24712fd0edc3ad18062980beae71c183493b49dc491adeebc5edc7ad18062980beae71c18349bb48dc091a3b7baab87d39ba619002e8eb1a173c98ace3e516712767ecec4b128588dd3e1dd5304801f4758d0b1e4cd6b9e24eccd8dd35720f71fb7534c32005d0d7352e78304947ca97c59d94b19c77ca565f4e1e062980beae71c183497a89b8933156f37c71fb7714c32005d0d7352e78303931dfd48de24ec458cd57e491e2f67371c32005d0d7352e783039cf117712c67a3e23f713b7af8b1a062980beae71c18349b98b5c2bee048cf5c54bdc878adbe7c50c8314405fd7b8e0c1a43c45dc89179bfbd7e2f67931c32005d0d7352e7830291f1677d2c5e6be2a4f12b7df8b18062980beae71c183c93845dc091779be200f14b7ffd30d8314405fd7b8e0c164bc5bdcc916b93e267713770c520d8314405fd7b8e0c1244489a2f829cb9d6891ef0271c721d5304801f4758d0b1e4cc25bc59d6051ceb3c51d8b34c32005d0d7352e7850bda3e46fc49d5c514eecf3878b3b262986410aa0af6b5cf0a07abf26eec48af2ae97fb883b2e1b1b062980beae71c183aadd53f68a3ba9621cef9178f1db1d9f8d0c8314405fd7b8e041d5ce127732c5b85e2aeef86c6418a400fabac6050faa75b8fcb9b81329c6759b3c5edc715adb304801f4758d0b1e54eb747127516cc7e7e5fee28ed55a86410aa0af6b5cf0a04a31c1e1d5e24ea0d89e2b25ae84dd315bd9304801f4758d0b1e54e909e24e9cd8bef3c41db3950d8314405fd7b8e04195629a0d77d2441de2675c77dc56320c52007d5de38207d5f95e71274bd4e3cbf23071c76f69c32005d0d7352e78509d8bc49d2c51974f49bc67e78ee15286410aa0af6b5cf0a02a27c8ade24e94a8cfc5120fd2b863b9ab619002e8eb1a173ca8ca1bc49d2051af17883b96bb1a062980beae71c1836a1c29fbc59d1c51afb8428e493edd313da8619002e8eb1a173ca8c6cbc49d1851bfcfcad1e28eeb8e86410aa0af6b5cf0a00a47c88de24e8a98860fca5dc51d5f6b18a400fabac6050faaf05c7127434ccb6bc51d5f002b2071d5ef30b956dc8910d3f25579b2b8e33c9693e59f0f3e032685c455bfd3c49d04314d5f94078b3bd66388f70063f6e67891ddfd3b503d1257fdfe58dc0910d3150592ef2eee789774acdc22b10e9f96fb8afb7f40d5485c758bc7a887273dccc3db6478bc4bfb35595c87a87979a8b8ff0b548bc455b73f94c5130de6251eba71c7bd843db25786ebf06fc4fd7fa05a24ae7a7da7c4cdfce18906f311f79a1e21eef8673b53dc3a84b88feafe06a81289ab5e178a3bc9605ec6b8d7741739d893a951cdfebbc4fd2d501d12579d8e91f836ee4e32989fcba4e4bda61f13d7efa28dabd903632171d56978131df3f772716321c3b2138fbe5bd6ae660f8c85c4559f7bc9cde24e2c98afb89ff94471636213278aeb6f272f15b71ca01a24aefac43418ee8482f9bb498e17372ed6b5eabdd2dbe409e296055481c45597c3e52fc49d50d086ab248a2abbf1b1aaa3649d7ba5f1d87c4c5aea96096c1d89ab2e4f177722415bde2c6e7cacea1c71cb5fc67f97bb895b2eb05524ae7ac44df12805e44e2268cb7f15374656913115ce6f8b5b36b05524ae7afcb0b89307da138fafbb31b28a33c42d7b55cf17b77c606b485cf558f69165ccdbff907861d88d9165655ebd4751de1f12d70fb01524ae3ac41c49eea481f664cc95f53871cb5ed75f4abc14effa024647e2aac33bc59d30d09678a2349e2c75636415978a5bfe263e2c19eb066c8cc4b57df1d871bc3be34e1668cb2f8a1b23ab78a8942ace7cbeb83e815191b8b6ef3c712709b4e50b125553dc1859452417b7fc2c4cfb8fad23716dd791b25fdc09026d89fa946e8cac628cf1f4d7f27071fd03a320716dd7262f88623ea2ba4554b970636415678b5b7eb6ff234cfb8fad21716dcfdd65d31744310f6f113746563176b9b0f70bd3fe632b485cdb73b01969d18e7890221ea870636415a78b5b7e49af11b72e405124aeed384cae137732405bde256e8cac2a8af3bae5971449f729e2d6072886c4b51da7893b11a03d3f206e8cac22fb85e3557c49be53dc7a014590b8b6e323e24e02684b4631dd50e285e35530ed3f4645e21adfa3c5053fda93514cb7e40bc7abf83d61da7f8c82c435be6d7f3b461d328ae986d22f1cafe257c4ad23908ac435aeef961abe1d63fb322a50d4f6027b942efbc7e2d6154843e21ad785e2021e6dc92aa63bd60bc7ab8869ff1f206e7d811424aef11c2b5f1117ec684b4631ddb15f385e05d3fea32812d778e2654d17e4684b5631dd6dbc70bc8ab7c9709d811424ae71c4896a9fb800475b328ae9866dbc70bcaa7f216edd818d90b8c6f14271818db66415d33d45dcf26b133f8d3f4adc36006b23719557f3bd088c2ba3986e8832516ef935faac30ed3f5291b8ca8bc79e5d40a32d59c574a7386376540861da7fa4217195159504ae1617cc684b5631dd73c52dbf766f14b73dc0ca485c6545491f17c4684f4631dda93fe4f30c71db05ac84c455d607c40530da92554cf72c71cb9f8aff274cfb8f8d91b8ca39595cf0a23d19c574630eb71bc42d7f4a621b98f61f1b21719573b1b8c0455bb28ae9ce690eb7f709d3fe636d24ae32a6f8e417cac828a61bae10b7fca9ca7a111b0d22719551d35413d89eac62ba73fcd99969ffb1361257be6f939aa69ac0f66414d30d17895bfed4c513924cfb8f9591b8f29d232e48d196ac62ba31abc02de2fa98834f0ad3fe632524ae5c7be4f3e202146dc9ba8713cb71cb9f934b8469ffb1341257ae33c50526da92554c37be08c5c48cae8fb97989b87d00dc09892b4fbc6773bdb8a0445bb28ae9b6f445e85679bcb8fd00f490b8f2fc94b880445bb28ae9c6bb5fd78aeb63ae6e92e3c5ed0fe0eb485c79a630b11fcacb2aa6db6a9dcb8f09d3fee3a0485c394e151784684f4631dd70b9b8e5b7e037c5ed13a043e2ca71a9b800445bb28ae99e286ef92d799eb87d0390b812c44926ee6bb8e0435b328ae9860bc52dbf2531edff0f8adb3f681c896b73bf212ef0d096ac62baf1187d3c4eeffa684d4cfbff77c4ed27348cc4b599b95735c0f2b28ae95279a58f69ff712724aecdbc565cb0a12d59c5748f901bc5f5d1b2f3c4ed2f348ac4b5bea94fa38e3c59c574cf10b77c1c72dccf8adb676810896b7d2f121760684b5631dda8d577b5b83e70c7b4ff2789db77680c896b3ddf2cf1f3900b30b425ab98eee3c42d1fdfc0b4ffe890b8d6c34f3a0859c57403ef022ee73261daffc691b856178f3c5f232ea8d096ac62ba51db90770197f76a71fb118d2071adaed51a72e8cb2aa61bce17d707bcd8f74f16b72fd10012d7ea3e242e98d096ac62ba47ca7e717d60675f94ac2f0e981812d76a1e212e88d09eac62ba678b5b3e76f73f8569ff1b44e25a4d7ccb760184b66415d38d9796793a7533bf2b4cfbdf1812d7f21e24b7890b1eb425ab98eee9e2968fd5c455abdbbf982912d7f2b8818e90554c37ae123e21ae0fac8669ff1b43e25a4ebcabc30d7484ac62babc709cebaf8469ff1b41e25a0e15bb11b28ae9065e38cef75161daff0690b876b747f68a0b14b425ab982e2f1c9713f3e3b97d8e192171ed2ea610770182b66415d30ddc2f2d8b69ff678ec47570874914f674c181b66415d3e585e3f2a28624d3fecf1889ebe09e262e30d096cc62babc703c8eff2b4cfb3f5324ae83bb4a5c50a02d6f16373e56c50bc7e38af26c4cfb3f4324ae9df1b8324266315d5e381edfbf17772c306124ae9dfd27718180b66415d30d5cc16fc7d3c51d0f4c1489cb3b515c00a03d59c5744f11b77c94170fc3fc7d71c7051344e2f27e4b5c00a02d718fc48d8f7550a079bbae9778a2d31d1b4c0c89ebce8e955bc40d7eb425ab98ee094281e6ed8b9fff99f67f06485c77f63a71831e6dc92aa61bce15d707c6f72a71c7081342e2eabbb7ec1337e0d196ac62ba516d8331558f784af427c51d2b4c0489ab8f974311328be99e25ae0f6c4f4cfbff1071c70b1340e2fa862324deb677031d6d7981b831b22a4a86d58b69ff278cc4f50d67881be0684b6631ddd3c4f5813a5c2c4cfb3f4124ae3bc44df84f891bdc684b5631dd7085b83e508f178b3b76a81889eb0e3f2e6e50a32d99c5744f16d707ea12d3fe477937770c512912d71df8668c90554c375c24ae0fd427a6fd3f4edc714485485c7794f47183196dc92ca6cb4becd313752499f67f22485c94e2c11d328be9c67d32d707ea76a1b8e389cab49eb8e25d0e4af1206415d3dd237bc5f581fa9d29eeb8a222ad27aef3c50d5eb425b3986e9cf85c1f98867840e791e28e2d2ad172e28aa7c76290bac18bb66415d38dd72aae15d707a6232aa71c2dee18a3022d27ae57881bb4684b6631dd4880ae0f4ccf7f11a6fdaf54ab898bfb103820ab986eb85c5c1f98a637883bced8b25613d72f881ba8684b66315d66cd9e27a6fdaf508b898bc2a73820ab986e8847a95d1f98b62f0bd3fe57a6c5c475bab8018ab66416d3e5419f79fbdfc2b4ff15692d714525e88f8a1b9c684b6631dd73c4f581f978af30ed7f255a4b5c514cd30d4ab425b3986ecce376a3b87e302faf14370630b2d612d7fbc40d48b425b3982ef3b8b58369ff2bd152e2e2a92f84cc62baf1d3f3d5e2fac13cdd2c0f16371e30929612d7dbc50d44b425b3982e3f3db7e91af95be2c60446d04ae2fa76619a0984ac62bae152717d60fefea330edff96b492b8ce1537f8d096cc62baf17363fcece8fa411b7e59dcd840612d24ae78ff629fb88187b66415d30dcc2c8098f6ffb1e2c6070a6a21719d2d6ed0a12d99c574e3cbd07e71fda02d9f97b815e1c6090a997be28a776c3e276ec0a12d99c574f93284454cfb3fb2b927ae67891b68684b6631dd584e2ccff583765d206ebca08039272e26f5c30199c574e3cacdf5013c57dc9841b23927ae9f1037b8d096cc62babc708c8389526299af5b6007734e5c57881b5c684b66315d5e38c66ee267e4ac3a98d8c15c13d7a3c40d2ab425b3986ee085632c8369ff0b9b6be2ba44dc80425b328be9f2c23156f17a71e30809e698b838c1206416d30dbc708c55fd337163091b9a63e28a6fd96e10a12d99c57479e118eb8869ff63560a37a6b081b9252ea650c701994f77f1c231d6f567721f71e30a6b9a5be27ab5b8c183b66416d3e585636c2a1eea61daff44734a5cf790bde2060eda92594cf774717d00abf857e2c617d630a7c47596b80183b66416d30d5187cef503ac221e168aa2086e8c614573495cf173ce0de2060cda92594cf714717d00eb882a2e4cfb9f602e898b9f7310328be9867832d1f503ac2b7e1160daff0dcd217145fdb88f8b1b24684b6631dd13e43671fd009bf81d61daff0dcc2171513f0e21b3986e38575c3f40865f1237eeb0843924aecbc50d0cb425b3986e24c07de2fa013230edff06a69eb84e123728d096ec62ba3ca18a31dc284cfbbf86a927ae8bc40d08b425b398ee61c213aa18cb478469ff5734e5c4f500b945dc60403bb28be99e26ae1fa094b78a1b8bd8c194131737cf11328be9062620c536fcbcb8f10863aa898b6add38207baaf45789eb072829eed3fe0371631203534d5c2f1177f0d196cc62ba07c4fb356f12d71f50d267e46f8b1b975830c5c47584c4d338eec0a32d99c574174525efdf15d72750d2078569ff7731c5c4f51c71071c6dc92ea63b14278ff78beb1b28e975e2c624be666a892b4e54d78a3bd8684b6631dd9d444db90f8beb1f28e967c48d49c8d412d753c41d64b425bb98eec1dc57ae11b71e402931edfff7881b93cd9b5ae2e2db2f426631dd651c239f16b72e402931edffb78a1b934d9b52e2626e2484ec62bacb7a907c4edc3a01a530edbf31a5c4f5fbe20e2cda92594c7755df2b9138dd7a01a5bc5cdc786cd654125794f489d23eeea0a21dd9c574d7f118f96b71eb079410e7be27891b8f4d9a4ae2ba40dc01455b328be96ee24725a6a570eb08941057fadf216e3c36670a89eb68896fdaee60a21dd9c57437f574e157008c29de5dbc87b8f1d8942924aeb8a7e10e22da925d4c37433cdde8d615288569ffa5f6c4754fd92bee00a22dd9c574b3bc52dcfa02a5fca2b8b1d88cda131733d1229428a69b25befdbe51dc7a0325c4fdd57f246e3c36a1e6c4159511fe5cdc81435b4a15d3cd12efd9bc53dcba0325c43b85f717371e67afe6c475bab80386b6942ea69b85a2bc18db9f48cc96e1c6e3acd59ab8e2e797abc51d2cb4658c62ba59ee269425c398de226e2cce5aad89eb09e20e12da326631dd2c5194f74fc56d0f50424cf5e4c6e26cd59ab82e177780d09612c5744f92170e3ecb1645796f10b74d40b6e6a6fdaf31717d9fb88383b6942aa61b4f00c68bc3cf5cf8ac841384a2bc184b3cc8d6ccb4ff3526ae8bc41d18b4a54431dd3db24f62f9f148f13f11f7ffb29c2814e5c5583e2053fb697d2db525aef8967a9bb8838276942aa61b5759c37e1e2feeff6679b4c4a4808bfd02a5fc3b71e370566a4b5c6f107730d09652c574af94615f91544adf1fa0282fc6f44fc58dc3d9a829711d29fbc51d08b4a35431dd1f12d75f889ff3fe9eb8bfcb1227138af2620cb39ff6bfa6c4f5327107016d29554c77b72755e3418af8a9dafd6d96e78beb1bc8769dcc76daff5a1257bcfd7da3b80380b69428a67bb0abad45d74b3ccaee9691e515e2fa06b2bd476639ed7f2d89ebb9e2763cda52aa98ee2aef0546c5967889d82d27cbaf8beb1bc8f6abe2c6e0a4d590b80e936bc5ed74b4a54431dd65afb616fd37892975dcf232c4b7e0df16d7379029eeabd65ea47a653524aed3c4ed70b4a55431dd75abb044c1dc92054ce37d9bf78aeb1bc8140f1f3d48dc389ca41a12977b4419ed29514c779dabad459748c97b0414e5c558e227f07801df8dc3c9d976e23a45dc4e465b4a15d3cda879f99b5272aaf478f2ebe3e2fa0632c59c71b398f67fdb892b9e7a713b186d29514c77d3abad45af17d747967892311e5f767d03994ac4dae8b699b8be4b782113a58ae966cf30f02fc5f59385a2bc184354703955dc189c8c6d26ae0bc5ed58b4a54431ddccabad45cf13d75f96a8de41515e94165f908e15370627615b892b7e1a8902a76ea7a21da58ae9665f6d1d10bf109c2eaecf2c3f2814e5456931edffb7881b83d5db56e28a6fd96e67a22d258ae996bada3a207e6a89a2b9aeef2cb17cbed8a1b4c94efbbf8dc415f7336e16b723d18e52c5744b5d6d2d8aa4f21871fd67799a700f18a53d5bdcf8abda3612573cd5e27620da52a2986ee9abad455f94ef17b71e59ce14d7379025be843d42dcf8abd6d8892bded5897776dc0e445b4a14d31de36a6b51dce42e3d1d4ad49a737d035962dafffb891b7f551a3b71fdacb81d87b69428a63be6d5d6a24fcbf1e2d6290b4579515a4cfb7f5771e3af3a6326ae78633bca8eb89d86b69428fa39f6d5d6a228125de2e9c803a2866354f0707d0359feadb8f1579d3113d78f88db59684b8962badbbada5a14659b4abc487d40fcccfe07e2fa06b2fcb4b8f157953113d71f89db51684b8962badbbcda5a140573a370ae5bc70cb1ec2bc4f50d648877081f266efc5563acc475b2b89d84b69428a65bc3d5d6a2cba444c1e003629e308af2a2a4ff25f71637feaa3056e28aaac46e07a12d250a7cd672b5b5e877a4e47428470b93afa2a43f946aa7fd1f237145f1d0dbc4ed1cb4a34431dddaaeb616bd494a4e211171c5ab2528a97461e9b58d91b8ce13b753d09612c5746bbcda5a54629b175194172545e596d2e5cdd6523a711d29fbc5ed14b4a34431dd9aafb616fdb2b8f5cf12550f28ca8b52aa9cf6bf74e23a47dcce405b4a14d3adfd6a6bd173c46d43962708457951ca27a4aa69ff4b26aebbcb8de27604da11f737b38be94ee56aeb80a8281f4573ddb664a1282f4a7a875433ed7fc9c44581508412c574a774b575405c11fdb0b8edc9125776ae6f20c359e2c6dde84a25aec3e4cfc46d3cda925d4c776a575b8be25ed4a3c46d57965f11d737b0a9f8e5e01f8a1b77a32a95b84e13b7e1684b8962ba53bcda5a1437bb4f14b76d595e2fae6f6053554cfb5f2a715d256ea3d196ec62ba53beda5a14c1ff4071db9821ee45509417a55c29df2c6eec8da244e27ab4b88d455b622680ec62ba53bfda5a14d3a11c236e3b3344d9a94bc4f50d6caac493c24b2b91b82e15b7a1684b7631ddb95c6d2dfaa4dc57dcf66688a2bc1f14d737b0a9678a1b77c56527aeef161ec9458962ba73bada5af41189c2b96e9b33509417a5c493b25140dd8dbba2b213d785e236106dc92ea63bc7abad4531e54fc9e950be4d28ca8b12e227ef185f6edc159399b8e24993af88db38b463af6417d39debd5d6a2df9392d3a13c40e224e3fa0636f19f255e8172e3ae88ccc4f51a711b85b66417969dfbd5d6a2781230fb8196455194f726717d039b1875daffacc415dfb0f789db20b4a34431dd16aeb616fdbab8fd90e5fb85a2bc28e1a9e2c65cbaacc4f54be236046dc97e44b6a5abad45af10b73fb23c5628ca8b6cf185281ed073632e5546e28adfe599d00e258ae9b676b5b5a8745db8f8761c257c5cdfc0ba62daffec7bdc779291b87e4edc06a02dd9c5745bbdda3a205e2bc97e176e88a2bc2821a6fd2f79af76e3c4152b171512dccaa32dd9c5745bbeda3a20ae887e52dcfec9f222717d039b283aedffa6892b6ad1b995465bb28be9b67eb5b528ee459d2a6e3f658927c25cdfc0bae217831f1137de36b669e2fa80b895465bb28be972b5d51737bde36940b7af324451dedf10d737b0ae9809a14831e94d125794fa702b8bb66417d3e56acb8b17bbe33d2cb7cf321c2a14e545b63f95980ddf8db9b56d92b82e16b7a2684bf603045c6ded2c9ede3d41dc7ecb1065a7d8ffc87691a44efbbf6ee28ae089c79fdd4aa21dd9c574b9dada5d3c6e5c723a9428cafb51717d03ebfa0571e36d2deb26aef3c5ad1cda925d4c976ffbcb896aef478adb871962aa158af222533c211b7335baf1b6b27512d7fd64bfb895433bb28be972b5b59a0fcb1e71fb32c3fd85a2bcc814337fff5d71e36d25eb24ae73c4ad14da925d4c97abadd5bd5f4a56948f8741e264e3fa06d6f1c7b2f1b4ffab26aef886f757e25608edc82ea6cbd5d6faa262493c11e8f66b068af222db9bc48db5a5ad9ab8ce14b722684b76315daeb6367381a43eb535f018a1282f329d216eac2d6595c4151385dd206e25d08eec62ba5c6de5283d1fd25384a2bcc8125f84d67ea97e95c4f553e256006dc92ea6cbd5569e9788dbc7599e2d51cac7f50dac6aed69ff57495c5789eb1c6dc92ca6cbd556be9f17b7afb330f71e32fd91ac3cedffb2892b8a7cba4ed196ec62ba5c6de58b2ba2a789dbdf59e28952d737b08ed78a1b673b5a36715d2aae43b425b3982e575be5dc223f2a6ebf67880741de2aae6f601d712bca8d356b99c475a2f0bb36b28be972b555563cc21e4f03ba7d9f81a2bcc814e375e922d2cb242ea63b40c82ca6cbd5d638625a89ef13770c32c48ba4f112b4eb1b585594198b5a996eacf5ec96b88e95f8d9c17582766417d3e56a6b3c51f922f3f585a138d15c29ae6f60557f20bbbe93b85be262665484cc62ba5c6d8d2f1e3b8eda83ee786488a2bc9f12d737b0aa97891b675f77b0c4150554f7895b30da915d4c97abaded889f6122c1b8639221a65aa1282f32c433154f1437ce3a074b5c2f16b750b425b3982e575bdb15d3a12c750f614d0f118af22243dc9fdd71d2d49d1257dc748dfb1a6e81684776315daeb6b62fdec58b998eddf1c910657c6e16d737b08a98f6df8ed59d12571440740b425b328be972b5558ff748c9e95028ca8b2c31edff9dc6984b5cf1aece35e21682766417d3e56aab2e6f9792d3a13c4928ca8b0c779af6df25aea88ee0fe186dc92ca6cbd5569dde2825a743f939a1780136155f804e91af8f2d97b8e23770f7c7684b66315daeb6eaf54a71c72c0b457991211efa892757bb71e5121700941033a8df7b208a1c1c3ff03d72d240dc378b62df8b9e2c314fd8a2670e3c4b5e38f02279d5c06be43f0cbc45de3110bf445c36f001f993814fc87503f1c0db4d03dc0b5c5e4cfbdfdd9bed252ea0651110400548f03b27f86edaff0331db0b60a045111000ea7720667b010c0040edec870000d4ca7e080040adec870000d4ca7e080040adec870000d4ca7e080040adec870000d4ca7e080040adec870000d4ca7e080040adec870000d4ca7e080040adec870000d4e9f66ffaff886f013bf0040ea10000000049454e44ae426082);

-- --------------------------------------------------------

--
-- Table structure for table `sous_famille`
--

CREATE TABLE `sous_famille` (
  `ID_FAMILLE` int(11) NOT NULL,
  `CODE_SOUS_FAMILLE` varchar(30) DEFAULT NULL,
  `LIBELLE_SOUS_FAMILLE` varchar(50) DEFAULT NULL,
  `NIVEAU_HIERARCHIQUE` varchar(100) DEFAULT NULL,
  `CODE_FAMILLE_PARENT` varchar(30) DEFAULT NULL,
  `NUM_COMPTE_MARCHANDISE` varchar(30) DEFAULT NULL,
  `NUM_COMPTE_VENTE` varchar(30) DEFAULT NULL,
  `METHODE_SUIVI_STOCK` varchar(15) DEFAULT NULL,
  `POURCENTAGE_REMISE` decimal(17,2) DEFAULT NULL,
  `TAUX_TVA` decimal(17,2) DEFAULT NULL,
  `DATE_CREATION` datetime DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `DATE_MODIFICATION` datetime DEFAULT NULL,
  `CODE_UTILISATEUR_MODIF` varchar(30) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sous_famille`
--

INSERT INTO `sous_famille` (`ID_FAMILLE`, `CODE_SOUS_FAMILLE`, `LIBELLE_SOUS_FAMILLE`, `NIVEAU_HIERARCHIQUE`, `CODE_FAMILLE_PARENT`, `NUM_COMPTE_MARCHANDISE`, `NUM_COMPTE_VENTE`, `METHODE_SUIVI_STOCK`, `POURCENTAGE_REMISE`, `TAUX_TVA`, `DATE_CREATION`, `CODE_UTILISATEUR_CREA`, `DATE_MODIFICATION`, `CODE_UTILISATEUR_MODIF`, `CODE_AGENCE`) VALUES
(4, '428160821125445', 'BOISSON NON ALCOLISEE', 'POUR DES PERSONNN NE PRENANT PAS L\'ALCOOL', '', '', '', 'Suivi simple', '0.00', '20.00', '2021-08-16 00:00:00', 'Suivi simple', '0000-00-00 00:00:00', '2021-08-16 00:00:00', ''),
(5, '426160821125813', 'BOISSON ALCOLISE', '', '', '', '', 'Suivi simple', '0.00', '0.00', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '151130821175930'),
(6, '42016082113342', 'EAU MINERALE', 'EAU DE SOURCE NATUREL', '', '', '', 'Suivi simple', '0.00', '0.00', '2021-08-16 00:00:00', '', '2021-08-16 00:00:00', '', '151130821175930'),
(7, '116230821161215', 'VIN', '', '', '', '', 'Suivi simple', '0.00', '0.00', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '151130821175930'),
(8, '113240821163811', 'HEBERGEMENT', 'HEBERGEMENT DE L\'HOTEL', '', '', '', 'Non Suivi', '0.00', '0.00', '2021-08-25 00:00:00', '', '2021-08-25 00:00:00', '', '151130821175930');

-- --------------------------------------------------------

--
-- Table structure for table `tarif`
--

CREATE TABLE `tarif` (
  `ID_TARIF` int(11) NOT NULL,
  `CODE_TARIF` varchar(30) NOT NULL,
  `LIBELLE_TARIF` varchar(30) NOT NULL,
  `DESCRIPTION_TARIF` varchar(100) NOT NULL,
  `TYPE_TARIF` varchar(30) NOT NULL COMMENT 'chambre, articles etc',
  `CODE_TYPE` varchar(30) NOT NULL COMMENT 'code de chambre ou article etc dont ont gèrent le type',
  `PRIX_TARIF1` double NOT NULL,
  `PRIX_TARIF2` double NOT NULL,
  `PRIX_TARIF3` double NOT NULL,
  `PRIX_TARIF4` double NOT NULL,
  `PRIX_TARIF5` double NOT NULL,
  `DATE_CREATION` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tarif`
--

INSERT INTO `tarif` (`ID_TARIF`, `CODE_TARIF`, `LIBELLE_TARIF`, `DESCRIPTION_TARIF`, `TYPE_TARIF`, `CODE_TYPE`, `PRIX_TARIF1`, `PRIX_TARIF2`, `PRIX_TARIF3`, `PRIX_TARIF4`, `PRIX_TARIF5`, `DATE_CREATION`) VALUES
(1, 'FORFAIT', 'FORFAIT POUR ENTREPRISE', '', '', '', 0, 0, 0, 0, 0, '2021-08-17 12:52:12'),
(2, 'TEST', 'TESTING', '', '', '', 0, 0, 0, 0, 0, '2021-08-17 13:40:28'),
(3, 'TRY', 'TRYING', '', '', '', 0, 0, 0, 0, 0, '2021-08-17 13:41:12');

-- --------------------------------------------------------

--
-- Table structure for table `tarif_client`
--

CREATE TABLE `tarif_client` (
  `ID_TARIF_CLIENT` int(11) NOT NULL,
  `ID_TARIF_PRIX` int(11) NOT NULL,
  `CODE_CLIENT` varchar(30) NOT NULL,
  `PRIX_TARIF_ENCOURS` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tarif_prix`
--

CREATE TABLE `tarif_prix` (
  `ID_TARIF` int(11) NOT NULL,
  `CODE_TARIF` varchar(30) NOT NULL,
  `LIBELLE_TARIF` varchar(30) NOT NULL,
  `DESCRIPTION_TARIF` varchar(100) NOT NULL,
  `TYPE_TARIF` varchar(30) NOT NULL COMMENT 'chambre, articles etc',
  `CODE_TYPE` varchar(30) NOT NULL COMMENT 'code de chambre ou article etc dont ont gèrent le type',
  `PRIX_TARIF1` double NOT NULL,
  `PRIX_TARIF2` double NOT NULL,
  `PRIX_TARIF3` double NOT NULL,
  `PRIX_TARIF4` double NOT NULL,
  `PRIX_TARIF5` double NOT NULL,
  `DATE_CREATION` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tarif_prix`
--

INSERT INTO `tarif_prix` (`ID_TARIF`, `CODE_TARIF`, `LIBELLE_TARIF`, `DESCRIPTION_TARIF`, `TYPE_TARIF`, `CODE_TYPE`, `PRIX_TARIF1`, `PRIX_TARIF2`, `PRIX_TARIF3`, `PRIX_TARIF4`, `PRIX_TARIF5`, `DATE_CREATION`) VALUES
(9, 'FORFAIT', 'FORFAIT POUR ENTREPRISE', '', 'Article', 'FAR125140821114439', 2500, 0, 0, 0, 0, '2021-08-17 18:02:06'),
(10, 'FORFAIT', 'FORFAIT POUR ENTREPRISE', '', 'Article', 'FAR24140821114836', 2700, 0, 0, 0, 0, '2021-08-17 18:02:18'),
(11, 'FORFAIT', 'FORFAIT POUR ENTREPRISE', '', 'Chambre', 'SG', 15000, 0, 0, 0, 0, '2021-08-17 18:02:29'),
(12, 'FORFAIT', 'FORFAIT POUR ENTREPRISE', '', 'Chambre', 'GC', 10000, 0, 0, 0, 0, '2021-08-17 18:02:38');

-- --------------------------------------------------------

--
-- Table structure for table `taxe_sejour_collectee`
--

CREATE TABLE `taxe_sejour_collectee` (
  `ID_TAXE_SEJOUR` int(11) NOT NULL,
  `CODE_CATEGORIE_HOTEL` varchar(30) DEFAULT NULL,
  `CODE_CLIENT` varchar(30) DEFAULT NULL,
  `NUM_RESERVATION` varchar(30) DEFAULT NULL,
  `NUM_FACTURE` varchar(30) DEFAULT NULL,
  `CODE_CHAMBRE` varchar(30) DEFAULT NULL,
  `TAXE_SEJOUR_COLLECTEE` decimal(17,2) DEFAULT NULL,
  `DATE_FACTURATION_TAXE` datetime DEFAULT NULL,
  `DATE_CREATION` datetime DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `CODE_AGENCE` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `type_chambre`
--

CREATE TABLE `type_chambre` (
  `ID_TYPE_CHAMBRE` int(10) NOT NULL,
  `LIBELLE_TYPE_CHAMBRE` varchar(50) NOT NULL,
  `DESCRIPTION` varchar(50) NOT NULL,
  `PRIX` double NOT NULL,
  `CODE_TYPE_CHAMBRE` varchar(20) NOT NULL,
  `DATE_CREATION` date NOT NULL,
  `CODE_UTILISATEUR_MODIF` varchar(20) NOT NULL,
  `DATE_MODIFICATION` date NOT NULL,
  `CODE_AGENCE` varchar(20) NOT NULL,
  `NOMBRE_LIT_UNE_PLACE` int(11) NOT NULL DEFAULT '0',
  `NOMBRE_LIT_DEUX_PLACES` int(11) NOT NULL DEFAULT '0',
  `TYPE` varchar(30) NOT NULL DEFAULT 'chambre',
  `CAPACITE` int(11) NOT NULL,
  `SUPERFICIE` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `type_chambre`
--

INSERT INTO `type_chambre` (`ID_TYPE_CHAMBRE`, `LIBELLE_TYPE_CHAMBRE`, `DESCRIPTION`, `PRIX`, `CODE_TYPE_CHAMBRE`, `DATE_CREATION`, `CODE_UTILISATEUR_MODIF`, `DATE_MODIFICATION`, `CODE_AGENCE`, `NOMBRE_LIT_UNE_PLACE`, `NOMBRE_LIT_DEUX_PLACES`, `TYPE`, `CAPACITE`, `SUPERFICIE`) VALUES
(4, 'SPECIAL GUEST', '', 55000, 'SG', '2021-08-13', '', '0000-00-00', '151130821175930', 0, 1, 'chambre', 0, 0),
(5, 'GRAND CONFORT', '', 35000, 'GC', '2021-08-13', '', '0000-00-00', '151130821175930', 0, 1, 'chambre', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `type_personnel`
--

CREATE TABLE `type_personnel` (
  `ID_TYPE_PERSONNEL` int(11) NOT NULL,
  `CODE_TYPE_PERSONNEL` varchar(30) DEFAULT NULL,
  `LIBELLE_TYPE_PERSONNEL` varchar(50) DEFAULT NULL,
  `CODE_UTILISATEUR_CREA` varchar(30) DEFAULT NULL,
  `DATE_CREATION` datetime DEFAULT CURRENT_TIMESTAMP,
  `CODE_UTILISATEUR_MODIF` varchar(30) DEFAULT NULL,
  `DATE_MODIFICATION` datetime DEFAULT NULL,
  `CODE_AGENCE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `utilisateurs`
--

CREATE TABLE `utilisateurs` (
  `ID_UTILISATEUR` int(11) NOT NULL,
  `CODE_UTILISATEUR` varchar(30) NOT NULL,
  `NOM_UTILISATEUR` varchar(100) NOT NULL,
  `GRIFFE_UTILISATEUR` varchar(5) NOT NULL,
  `CATEG_UTILISATEUR` varchar(50) NOT NULL,
  `AGENCE_TRAV_NUMBER` int(5) NOT NULL,
  `AGENCE_CREATE_NUMBER` int(11) NOT NULL,
  `PASSWORD_UTILISATEUR` varchar(32) NOT NULL,
  `DEBUT_ACCES` datetime NOT NULL,
  `FIN_ACCES` datetime NOT NULL,
  `NOM_CONNEXION` varchar(15) NOT NULL,
  `DATE_CHANGE_PWD` datetime NOT NULL,
  `DATE_CREATION` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DATE_EXPIRATION` datetime NOT NULL,
  `DATE_DERNIERE_MAJ` datetime NOT NULL,
  `POSTE_UTILISATEUR` varchar(100) NOT NULL,
  `CODE_UTILISATEUR_MAJ` varchar(10) NOT NULL,
  `ETAT_UTILISATEUR` varchar(1) NOT NULL,
  `CODE_UTILISATEUR_CREA` varchar(10) NOT NULL,
  `PEUT_FAIRE_REMISE` varchar(1) NOT NULL,
  `PRIX_VENTE_MODIFIABLE` varchar(1) NOT NULL,
  `PEUT_FAIRE_DEDUCTION_CLIENT` varchar(1) NOT NULL,
  `PEUT_ANNULER_COMMANDE` varchar(1) NOT NULL,
  `PEUT_CLOTURER_MAIN_COURANTE` varchar(1) NOT NULL,
  `CONNEXION_DISTANTE` varchar(1) NOT NULL,
  `PEUT_ATTRIBUER_GRATUITE` varchar(1) NOT NULL,
  `PEUT_MODIFIER_TAXE_SEJOUR` varchar(1) NOT NULL,
  `LANGUE_PAR_DEFAUT` varchar(50) NOT NULL,
  `NUM_AGENCE` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `utilisateurs`
--

INSERT INTO `utilisateurs` (`ID_UTILISATEUR`, `CODE_UTILISATEUR`, `NOM_UTILISATEUR`, `GRIFFE_UTILISATEUR`, `CATEG_UTILISATEUR`, `AGENCE_TRAV_NUMBER`, `AGENCE_CREATE_NUMBER`, `PASSWORD_UTILISATEUR`, `DEBUT_ACCES`, `FIN_ACCES`, `NOM_CONNEXION`, `DATE_CHANGE_PWD`, `DATE_CREATION`, `DATE_EXPIRATION`, `DATE_DERNIERE_MAJ`, `POSTE_UTILISATEUR`, `CODE_UTILISATEUR_MAJ`, `ETAT_UTILISATEUR`, `CODE_UTILISATEUR_CREA`, `PEUT_FAIRE_REMISE`, `PRIX_VENTE_MODIFIABLE`, `PEUT_FAIRE_DEDUCTION_CLIENT`, `PEUT_ANNULER_COMMANDE`, `PEUT_CLOTURER_MAIN_COURANTE`, `CONNEXION_DISTANTE`, `PEUT_ATTRIBUER_GRATUITE`, `PEUT_MODIFIER_TAXE_SEJOUR`, `LANGUE_PAR_DEFAUT`, `NUM_AGENCE`) VALUES
(19, 'ADMIN', 'SUPER ADMINISTRATEUR', 'SAD', 'ADMINISTRATION', 0, 0, 'ADMIN', '2021-08-25 00:00:00', '2021-08-25 00:00:00', ' ', '2021-08-25 00:00:00', '2021-08-25 00:00:00', '0000-00-00 00:00:00', '2021-08-25 00:00:00', ' ', ' ', ' ', 'admin', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '151130821175930');

-- --------------------------------------------------------

--
-- Table structure for table `utilisateur_acces`
--

CREATE TABLE `utilisateur_acces` (
  `ID_ACCES` int(11) NOT NULL,
  `DASHBOARD` int(1) DEFAULT NULL,
  `PLANNING` int(1) DEFAULT NULL,
  `ARRIVEES` int(1) DEFAULT NULL,
  `EN_CHAMBRES` int(1) DEFAULT NULL,
  `DEPARTS` int(1) DEFAULT NULL,
  `ATTRIBUER_CHAMBRE` int(1) DEFAULT NULL,
  `MESSAGES` int(1) DEFAULT NULL,
  `FACTURATION` int(1) DEFAULT NULL,
  `CLOTURE` int(1) DEFAULT NULL,
  `RAPPORT_RECEPTION` int(1) NOT NULL,
  `CARDEX` int(1) DEFAULT NULL,
  `NOUVELLE_RESERVATION` int(1) DEFAULT NULL,
  `MODIFIER_RESERVATION` int(1) DEFAULT NULL,
  `FICHE_DE_POLICE` int(1) DEFAULT NULL,
  `DISPONIBILITE_ET_TARIFS` int(1) DEFAULT NULL,
  `PLAN_DE_CHAMBRE` int(1) DEFAULT NULL,
  `RAPPORT_RESERVATION` int(1) NOT NULL,
  `STATUTS_DES_CHAMBRES` int(1) DEFAULT NULL,
  `HISTORIQUES_DES_CHAMBRES` int(1) DEFAULT NULL,
  `HORS_SERVICES` int(1) DEFAULT NULL,
  `OBJETS_TROUVES_PERDUS` int(1) DEFAULT NULL,
  `RAPPORT_SERVICE_ETAGE` int(1) NOT NULL,
  `CLIENT_EN_CHAMBRE_FACTURATION` int(1) DEFAULT NULL,
  `PAYMASTER_FACTURATION` int(1) DEFAULT NULL,
  `AU_COMPTANT_FACTURATION` int(1) DEFAULT NULL,
  `RAPPORT_BAR_RESTAURANT` int(1) NOT NULL,
  `GESTION_DES_COMPTES` int(1) DEFAULT NULL,
  `LISTE_DES_COMPTES` int(1) DEFAULT NULL,
  `RECHARGE` int(1) DEFAULT NULL,
  `CAUTIONS` int(1) NOT NULL,
  `RAPPORT_COMPTABILITE` int(1) NOT NULL,
  `MOUVEMENT` int(1) DEFAULT NULL,
  `INVENTAIRE` int(1) DEFAULT NULL,
  `FICHE_DE_PRODUIT` int(1) DEFAULT NULL,
  `FOURNISSEURS` int(1) DEFAULT NULL,
  `RAPPORT_ECONOMAT` int(1) NOT NULL,
  `PETITE_CAISSE` int(1) DEFAULT NULL,
  `GRANDE_CAISSE` int(1) DEFAULT NULL,
  `PETIT_MAGAZIN` int(1) DEFAULT NULL,
  `GRAND_MAGAZIN` int(1) DEFAULT NULL,
  `SESSION_ADMIN` int(1) DEFAULT NULL,
  `CONFIGURATION` int(1) DEFAULT NULL,
  `SERVICE_TECHNIQUE` int(1) DEFAULT NULL,
  `SECURITE` int(1) DEFAULT NULL,
  `MENU_RECEPTION` int(1) NOT NULL,
  `MENU_RESERVATION` int(1) NOT NULL,
  `MENU_ADMINISTRATEUR` int(1) NOT NULL,
  `MENU_SERVICE_ETAGE` int(1) NOT NULL,
  `MENU_BAR_RESTAURANT` int(1) NOT NULL,
  `MENU_COMPTABILITE` int(1) NOT NULL,
  `MENU_ECONOMAT` int(1) NOT NULL,
  `CODE_UTILISATEUR` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `utilisateur_acces`
--

INSERT INTO `utilisateur_acces` (`ID_ACCES`, `DASHBOARD`, `PLANNING`, `ARRIVEES`, `EN_CHAMBRES`, `DEPARTS`, `ATTRIBUER_CHAMBRE`, `MESSAGES`, `FACTURATION`, `CLOTURE`, `RAPPORT_RECEPTION`, `CARDEX`, `NOUVELLE_RESERVATION`, `MODIFIER_RESERVATION`, `FICHE_DE_POLICE`, `DISPONIBILITE_ET_TARIFS`, `PLAN_DE_CHAMBRE`, `RAPPORT_RESERVATION`, `STATUTS_DES_CHAMBRES`, `HISTORIQUES_DES_CHAMBRES`, `HORS_SERVICES`, `OBJETS_TROUVES_PERDUS`, `RAPPORT_SERVICE_ETAGE`, `CLIENT_EN_CHAMBRE_FACTURATION`, `PAYMASTER_FACTURATION`, `AU_COMPTANT_FACTURATION`, `RAPPORT_BAR_RESTAURANT`, `GESTION_DES_COMPTES`, `LISTE_DES_COMPTES`, `RECHARGE`, `CAUTIONS`, `RAPPORT_COMPTABILITE`, `MOUVEMENT`, `INVENTAIRE`, `FICHE_DE_PRODUIT`, `FOURNISSEURS`, `RAPPORT_ECONOMAT`, `PETITE_CAISSE`, `GRANDE_CAISSE`, `PETIT_MAGAZIN`, `GRAND_MAGAZIN`, `SESSION_ADMIN`, `CONFIGURATION`, `SERVICE_TECHNIQUE`, `SECURITE`, `MENU_RECEPTION`, `MENU_RESERVATION`, `MENU_ADMINISTRATEUR`, `MENU_SERVICE_ETAGE`, `MENU_BAR_RESTAURANT`, `MENU_COMPTABILITE`, `MENU_ECONOMAT`, `CODE_UTILISATEUR`) VALUES
(16, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 'ADMIN');

-- --------------------------------------------------------

--
-- Table structure for table `utilisateur_caisse`
--

CREATE TABLE `utilisateur_caisse` (
  `ID_UTILISATEUR_CAISSE` int(11) NOT NULL,
  `CODE_UTILISATEUR` varchar(100) NOT NULL,
  `CODE_CAISSE` varchar(300) NOT NULL,
  `SOLDE_CAISSE` double NOT NULL,
  `DATE_SOLDE` datetime NOT NULL,
  `DATE_CLOTURE` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `utilisateur_magazin`
--

CREATE TABLE `utilisateur_magazin` (
  `ID_UTILISATEUR_CAISSE` int(11) NOT NULL,
  `CODE_UTILISATEUR` varchar(100) NOT NULL,
  `CODE_MAGAZIN` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `ville`
--

CREATE TABLE `ville` (
  `ID_VILLE` int(11) NOT NULL,
  `NOM_VILLE` varchar(56) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ville`
--

INSERT INTO `ville` (`ID_VILLE`, `NOM_VILLE`) VALUES
(1, 'YAOUNDE'),
(2, 'DOUALA'),
(3, 'PARIS'),
(4, 'DUBAI'),
(5, 'GENEVE'),
(6, 'BARCELONE');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `agence`
--
ALTER TABLE `agence`
  ADD PRIMARY KEY (`ID_AGENCE`);

--
-- Indexes for table `article`
--
ALTER TABLE `article`
  ADD PRIMARY KEY (`ID_ARTICLE`);

--
-- Indexes for table `caisse`
--
ALTER TABLE `caisse`
  ADD PRIMARY KEY (`ID_CAISSE`);

--
-- Indexes for table `categorie_chambre`
--
ALTER TABLE `categorie_chambre`
  ADD PRIMARY KEY (`ID_CATEGORIE_CHAMBRE`);

--
-- Indexes for table `categorie_client`
--
ALTER TABLE `categorie_client`
  ADD PRIMARY KEY (`ID_TYPE_CLIENT`);

--
-- Indexes for table `category_hotel_taxe_sejour_collectee`
--
ALTER TABLE `category_hotel_taxe_sejour_collectee`
  ADD PRIMARY KEY (`ID_CATEGORIE`);

--
-- Indexes for table `chambre`
--
ALTER TABLE `chambre`
  ADD PRIMARY KEY (`ID_CHAMBRE`);

--
-- Indexes for table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`ID_CLIENT`);

--
-- Indexes for table `cloture`
--
ALTER TABLE `cloture`
  ADD PRIMARY KEY (`ID_CLOTURE`);

--
-- Indexes for table `compte`
--
ALTER TABLE `compte`
  ADD PRIMARY KEY (`ID_COMPTE`);

--
-- Indexes for table `entreprise`
--
ALTER TABLE `entreprise`
  ADD PRIMARY KEY (`ID_ENTREPRISE`);

--
-- Indexes for table `facture`
--
ALTER TABLE `facture`
  ADD PRIMARY KEY (`ID_FACTURE`);

--
-- Indexes for table `famille`
--
ALTER TABLE `famille`
  ADD PRIMARY KEY (`ID_FAMILLE`);

--
-- Indexes for table `forfait_salle`
--
ALTER TABLE `forfait_salle`
  ADD PRIMARY KEY (`ID_FORFAIT_SALE`);

--
-- Indexes for table `groupe_article`
--
ALTER TABLE `groupe_article`
  ADD PRIMARY KEY (`ID_GROUPE_ARTICLE`);

--
-- Indexes for table `ligne_facture`
--
ALTER TABLE `ligne_facture`
  ADD PRIMARY KEY (`ID_LIGNE_FACTURE`);

--
-- Indexes for table `main_courante`
--
ALTER TABLE `main_courante`
  ADD PRIMARY KEY (`ID_MAIN_COURANTE`);

--
-- Indexes for table `main_courante_generale`
--
ALTER TABLE `main_courante_generale`
  ADD PRIMARY KEY (`ID_MAIN_COURANTE_GENERALE`);

--
-- Indexes for table `main_courante_journaliere`
--
ALTER TABLE `main_courante_journaliere`
  ADD PRIMARY KEY (`ID_MAIN_COURANTE_JOURNALIERE`);

--
-- Indexes for table `mode_reglement`
--
ALTER TABLE `mode_reglement`
  ADD PRIMARY KEY (`ID_MODE_PAIMENT`);

--
-- Indexes for table `monnaie`
--
ALTER TABLE `monnaie`
  ADD PRIMARY KEY (`ID_MONNAIE`);

--
-- Indexes for table `mvt_compte`
--
ALTER TABLE `mvt_compte`
  ADD PRIMARY KEY (`ID_MVT_COMPTE`);

--
-- Indexes for table `occupation_chambre`
--
ALTER TABLE `occupation_chambre`
  ADD PRIMARY KEY (`ID_OCCUPATION_CHAMBRE`);

--
-- Indexes for table `pays`
--
ALTER TABLE `pays`
  ADD PRIMARY KEY (`ID_PAYS`);

--
-- Indexes for table `personnel`
--
ALTER TABLE `personnel`
  ADD PRIMARY KEY (`ID_PERSONNEL`);

--
-- Indexes for table `planning`
--
ALTER TABLE `planning`
  ADD PRIMARY KEY (`ID_PLANNING`);

--
-- Indexes for table `planning_hebdomadaire`
--
ALTER TABLE `planning_hebdomadaire`
  ADD PRIMARY KEY (`ID_PLANNING_HEBDOMADAIRE`);

--
-- Indexes for table `reglement`
--
ALTER TABLE `reglement`
  ADD PRIMARY KEY (`ID_REGLEMENT`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`ID_RESERVATION`);

--
-- Indexes for table `reserve_conf`
--
ALTER TABLE `reserve_conf`
  ADD PRIMARY KEY (`ID_RESERVATION`);

--
-- Indexes for table `reserve_temp`
--
ALTER TABLE `reserve_temp`
  ADD PRIMARY KEY (`ID_RESERVATION`);

--
-- Indexes for table `societe`
--
ALTER TABLE `societe`
  ADD PRIMARY KEY (`ID_SOCIETE`);

--
-- Indexes for table `sous_famille`
--
ALTER TABLE `sous_famille`
  ADD PRIMARY KEY (`ID_FAMILLE`);

--
-- Indexes for table `tarif`
--
ALTER TABLE `tarif`
  ADD PRIMARY KEY (`ID_TARIF`);

--
-- Indexes for table `tarif_client`
--
ALTER TABLE `tarif_client`
  ADD PRIMARY KEY (`ID_TARIF_CLIENT`);

--
-- Indexes for table `tarif_prix`
--
ALTER TABLE `tarif_prix`
  ADD PRIMARY KEY (`ID_TARIF`);

--
-- Indexes for table `taxe_sejour_collectee`
--
ALTER TABLE `taxe_sejour_collectee`
  ADD PRIMARY KEY (`ID_TAXE_SEJOUR`);

--
-- Indexes for table `type_chambre`
--
ALTER TABLE `type_chambre`
  ADD PRIMARY KEY (`ID_TYPE_CHAMBRE`);

--
-- Indexes for table `type_personnel`
--
ALTER TABLE `type_personnel`
  ADD PRIMARY KEY (`ID_TYPE_PERSONNEL`);

--
-- Indexes for table `utilisateurs`
--
ALTER TABLE `utilisateurs`
  ADD PRIMARY KEY (`ID_UTILISATEUR`);

--
-- Indexes for table `utilisateur_acces`
--
ALTER TABLE `utilisateur_acces`
  ADD PRIMARY KEY (`ID_ACCES`);

--
-- Indexes for table `utilisateur_caisse`
--
ALTER TABLE `utilisateur_caisse`
  ADD PRIMARY KEY (`ID_UTILISATEUR_CAISSE`);

--
-- Indexes for table `utilisateur_magazin`
--
ALTER TABLE `utilisateur_magazin`
  ADD PRIMARY KEY (`ID_UTILISATEUR_CAISSE`);

--
-- Indexes for table `ville`
--
ALTER TABLE `ville`
  ADD PRIMARY KEY (`ID_VILLE`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `agence`
--
ALTER TABLE `agence`
  MODIFY `ID_AGENCE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `article`
--
ALTER TABLE `article`
  MODIFY `ID_ARTICLE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `caisse`
--
ALTER TABLE `caisse`
  MODIFY `ID_CAISSE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `categorie_chambre`
--
ALTER TABLE `categorie_chambre`
  MODIFY `ID_CATEGORIE_CHAMBRE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=163;

--
-- AUTO_INCREMENT for table `categorie_client`
--
ALTER TABLE `categorie_client`
  MODIFY `ID_TYPE_CLIENT` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `category_hotel_taxe_sejour_collectee`
--
ALTER TABLE `category_hotel_taxe_sejour_collectee`
  MODIFY `ID_CATEGORIE` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `chambre`
--
ALTER TABLE `chambre`
  MODIFY `ID_CHAMBRE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `client`
--
ALTER TABLE `client`
  MODIFY `ID_CLIENT` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `cloture`
--
ALTER TABLE `cloture`
  MODIFY `ID_CLOTURE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `compte`
--
ALTER TABLE `compte`
  MODIFY `ID_COMPTE` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `entreprise`
--
ALTER TABLE `entreprise`
  MODIFY `ID_ENTREPRISE` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `facture`
--
ALTER TABLE `facture`
  MODIFY `ID_FACTURE` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `famille`
--
ALTER TABLE `famille`
  MODIFY `ID_FAMILLE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `forfait_salle`
--
ALTER TABLE `forfait_salle`
  MODIFY `ID_FORFAIT_SALE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=82;

--
-- AUTO_INCREMENT for table `groupe_article`
--
ALTER TABLE `groupe_article`
  MODIFY `ID_GROUPE_ARTICLE` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ligne_facture`
--
ALTER TABLE `ligne_facture`
  MODIFY `ID_LIGNE_FACTURE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `main_courante`
--
ALTER TABLE `main_courante`
  MODIFY `ID_MAIN_COURANTE` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=119;

--
-- AUTO_INCREMENT for table `main_courante_generale`
--
ALTER TABLE `main_courante_generale`
  MODIFY `ID_MAIN_COURANTE_GENERALE` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=86;

--
-- AUTO_INCREMENT for table `main_courante_journaliere`
--
ALTER TABLE `main_courante_journaliere`
  MODIFY `ID_MAIN_COURANTE_JOURNALIERE` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `mode_reglement`
--
ALTER TABLE `mode_reglement`
  MODIFY `ID_MODE_PAIMENT` int(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `monnaie`
--
ALTER TABLE `monnaie`
  MODIFY `ID_MONNAIE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=134;

--
-- AUTO_INCREMENT for table `mvt_compte`
--
ALTER TABLE `mvt_compte`
  MODIFY `ID_MVT_COMPTE` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `occupation_chambre`
--
ALTER TABLE `occupation_chambre`
  MODIFY `ID_OCCUPATION_CHAMBRE` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=192;

--
-- AUTO_INCREMENT for table `pays`
--
ALTER TABLE `pays`
  MODIFY `ID_PAYS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=240;

--
-- AUTO_INCREMENT for table `personnel`
--
ALTER TABLE `personnel`
  MODIFY `ID_PERSONNEL` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `planning`
--
ALTER TABLE `planning`
  MODIFY `ID_PLANNING` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `planning_hebdomadaire`
--
ALTER TABLE `planning_hebdomadaire`
  MODIFY `ID_PLANNING_HEBDOMADAIRE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `reglement`
--
ALTER TABLE `reglement`
  MODIFY `ID_REGLEMENT` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `reservation`
--
ALTER TABLE `reservation`
  MODIFY `ID_RESERVATION` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `reserve_conf`
--
ALTER TABLE `reserve_conf`
  MODIFY `ID_RESERVATION` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `reserve_temp`
--
ALTER TABLE `reserve_temp`
  MODIFY `ID_RESERVATION` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `societe`
--
ALTER TABLE `societe`
  MODIFY `ID_SOCIETE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `sous_famille`
--
ALTER TABLE `sous_famille`
  MODIFY `ID_FAMILLE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `tarif`
--
ALTER TABLE `tarif`
  MODIFY `ID_TARIF` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tarif_client`
--
ALTER TABLE `tarif_client`
  MODIFY `ID_TARIF_CLIENT` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `tarif_prix`
--
ALTER TABLE `tarif_prix`
  MODIFY `ID_TARIF` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `taxe_sejour_collectee`
--
ALTER TABLE `taxe_sejour_collectee`
  MODIFY `ID_TAXE_SEJOUR` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `type_chambre`
--
ALTER TABLE `type_chambre`
  MODIFY `ID_TYPE_CHAMBRE` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `type_personnel`
--
ALTER TABLE `type_personnel`
  MODIFY `ID_TYPE_PERSONNEL` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `utilisateurs`
--
ALTER TABLE `utilisateurs`
  MODIFY `ID_UTILISATEUR` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `utilisateur_acces`
--
ALTER TABLE `utilisateur_acces`
  MODIFY `ID_ACCES` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `utilisateur_caisse`
--
ALTER TABLE `utilisateur_caisse`
  MODIFY `ID_UTILISATEUR_CAISSE` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `utilisateur_magazin`
--
ALTER TABLE `utilisateur_magazin`
  MODIFY `ID_UTILISATEUR_CAISSE` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ville`
--
ALTER TABLE `ville`
  MODIFY `ID_VILLE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
