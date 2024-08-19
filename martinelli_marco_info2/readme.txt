Struttura:

-classe asrtratta Referto
-sottoclassi di Referto (RefertoSingolo, RefertoMultiplo, RefertoImmagine)
-classe Paziente
-classe Esame (da inserire nella lista di Referto Multiplo)
-classe GestoreReferti che contiene anche il MAIN
-classe ENUM risultatoReferto
-classi eccezioni per alcuni controlli

ho diviso tutto in 3 package differenti


nel gestoreReferti ho usato 2 liste per i pazienti e i referti e ho implementato i vari metodi (messi public per consentire di creare un MAIN fuori dal package)
ho creato un algoritmo di sort per stampare in ordine di criticità



per motivi di TEMPO non sono riuscito a creare un MAIN ben compilato ne commentare bene tutto ne implementare lettura dati da FILE, tutte cose di mia
competenza ma il tempo mi ha fregato