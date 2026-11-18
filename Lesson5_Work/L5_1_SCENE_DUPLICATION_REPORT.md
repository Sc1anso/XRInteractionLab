# Lezione 5 — Verifica SDK 209 e duplicazione scena

**Data:** 2026-11-18  
**Progetto:** `C:\Users\Scianso\Documents\GitHub\XRInteractionLab`  
**Scena originale:** `Assets/Scenes/SampleScene.unity`  
**Scena Lezione 5:** `Assets/Scenes/Lesson5_MixedReality.unity`

## Esito sintetico

La migrazione dei pacchetti Meta alla versione 209 risulta completata e risolta nel Package Manager. Al controllo iniziale, prima della duplicazione, Unity non risultava in compilazione e la query della Console non ha trovato errori (`0` errori). In un controllo MCP successivo è comparso un errore loggato durante la lettura serializzata di un getter `OVRManager`; lo stack trace lo collega alla richiesta di ispezione MCP, non a una compilazione. La validazione statica della nuova scena ha riportato `0` problemi, `0` missing script e `0` prefab rotti. Non ho eseguito build, Play Mode o test Quest.

Ho creato la scena Lezione 5 con Unity MCP duplicando l’asset completo della `SampleScene`; la copia è aperta nell’Editor, pulita e non aggiunta ai Build Settings. La scena originale e i suoi riferimenti non sono stati modificati. Non ho installato pacchetti, configurato MRUK, disattivato GameObject o cambiato impostazioni XR.

## 1. Istruzioni e Git

- La ricerca del file fisico `AGENTS.md` nella root e nelle sottocartelle non ha trovato una copia nel checkout attuale. Ho applicato le istruzioni di progetto fornite dall’insegnante in chat: preservare Lessons 1–4, evitare modifiche fuori ambito, controllare la scena prima di intervenire e non cambiare MRUK/Build Settings in questa fase.
- **Git prima:** branch `main`, HEAD `9895b95` (`lesson 5 impl`), `git status --short` vuoto.
- **Git dopo:** solo i nuovi file previsti da questo incarico risultano non tracciati:

  ```text
  ?? Assets/Scenes/Lesson5_MixedReality.unity
  ?? Assets/Scenes/Lesson5_MixedReality.unity.meta
  ?? Lesson5_Work/L5_1_SCENE_DUPLICATION_REPORT.md
  ```

- Nessun commit creato.
- La scena sorgente corrisponde al blob Git di `HEAD` (`63350eae4f42c03e1c179bbb85df6c1ba87b1e5d`); il file `SampleScene.unity` non è stato cambiato.

## 2. Versioni e stato della migrazione

Unity è `6000.3.9f1` (revision `7a9955a4f2fa`). La manifest e il lock file, confermati anche dalla lista live del Package Manager Unity, riportano:

| Pacchetto | Versione risolta | Nota |
|---|---:|---|
| `com.meta.xr.sdk.core` | `209.0.0` | diretto |
| `com.meta.xr.sdk.interaction` | `209.0.0` | dipendenza risolta dal pacchetto OVR; non è una dipendenza diretta nella manifest |
| `com.meta.xr.sdk.interaction.ovr` | `209.0.0` | diretto |
| `com.meta.xr.sdk.haptics` | `209.0.0` | diretto |
| `com.unity.xr.openxr` | `1.18.0` | diretto |
| `com.unity.xr.management` | `4.5.3` | risolto |
| `com.unity.xr.hands` | `1.7.3` | risolto |
| `com.unity.inputsystem` | `1.18.0` | diretto |
| `com.unity.render-pipelines.universal` | `17.3.0` | diretto |

MRUK (`com.meta.xr.mrutilitykit`) non è installato. Nessun pacchetto è stato aggiunto o aggiornato durante questo incarico.

### Console e problemi di migrazione

- **Errori Unity/compilazione:** la Console MCP ha restituito zero log di tipo Error al gate iniziale; lo stato Editor indicava `is_compiling=false` e nessun domain reload in sospeso. Questo non equivale a una build o a una prova runtime.
- **Errore apparso durante l’ispezione successiva:** `GetHmdColorDesc: Failed to get Hmd color description` (`OVRPlugin.cs:11396`). Lo stack trace mostra `OVRManager.get_nativeColorGamut()` chiamato da `GameObjectSerializer.GetComponentData` del MCP mentre serializzava i componenti. Il log è quindi stato prodotto dalla lettura MCP dell’Inspector; non è stato osservato al gate iniziale e non costituisce prova di errore di compilazione o di migrazione. La causa nativa sottostante non è stata verificata; non ho ripetuto la lettura di quel getter né cancellato il log.
- **Project Setup Tool:** la Console mostra il riepilogo «2 outstanding Recommended fixes». Non sono state applicate. Sono raccomandazioni, non errori di compilazione; i fix specifici vanno aperti e valutati separatamente prima di una build per Quest.
- **Warning da approfondire:** la Console ha mostrato `Script 'CharacterController' has the same name as built-in Unity component. AddComponent and GetComponent will not work with this script.` Non ho trovato un sorgente corrispondente sotto `Assets/`; l’origine e l’eventuale relazione con la migrazione non sono accertate. Non è comparso come errore di compilazione. È un problema preesistente o di provenienza non verificata da investigare prima di affidarsi a un componente custom con quel nome.
- **Messaggi MCP:** alcune ricerche iniziali hanno interrogato nomi di GameObject come se fossero nomi di componenti e hanno prodotto warning di ricerca; un successivo warning WebSocket MCP («not initialised») è del canale MCP, non un errore Unity dei pacchetti. Non vanno scambiati per errori di compilazione della migrazione.
- Il controllo live dei pacchetti non mostra dipendenze mancanti: il Package Manager ha elencato 51 pacchetti installati, inclusi i pacchetti XR sopra indicati.

**Valutazione fase 1:** nessun errore bloccante di compilazione o risoluzione pacchetti che richieda di fermare la duplicazione. Restano le raccomandazioni Meta e il warning `CharacterController` da chiarire; sono riportati come limitazioni, non come migrazione convalidata su Quest.

## 3. Scena, rig e Passthrough dopo la migrazione

Prima della copia Unity MCP riportava `SampleScene` attiva, caricata, non in Play Mode e `isDirty=false`. La scena originale aveva 12 oggetti radice. Dopo la copia e l’apertura della nuova scena, `Lesson5_MixedReality` è attiva, caricata, non sporca (`isDirty=false`) e ha anch’essa 12 oggetti radice.

Le radici duplicate sono: `Directional Light`, `Global Volume`, `Environment`, `ControlStation`, `EventSystem`, `LightController`, `OVRCameraRig`, `FloorTeleportSurface`, `ISDKExampleMenu`, `Lesson4_AdvancedInteractions`, `HandLeft PointerPose`, `HandRight PointerPose`.

### Componenti e conteggi verificati nella copia

| Elemento | Conteggio / path verificato |
|---|---|
| `OVRCameraRig` | 1, root `OVRCameraRig`; componenti includono `OVRCameraRig`, `OVRManager`, `OVRHeadsetEmulator`, `OVRPassthroughLayer` |
| `OVRComprehensiveInteractionRig` | 1, `OVRCameraRig/OVRComprehensiveInteractionRig` |
| `Locomotor` | 1, `OVRCameraRig/OVRComprehensiveInteractionRig/Locomotor` |
| `EventSystem` | 1, root; mantiene `InputSystemUIInputModule`, `PointableCanvasModule` e `BaseInput` |
| Interactor mani per distanza | 2 `DistanceHandGrabInteractor`, sotto i rami sinistro e destro degli interactor |
| Interactor controller per distanza | 2 GameObject `DistanceControllerHandGrabInteractor`, distinti dalla route a mani nude; includono `ControllerRef`/decorator |
| `OVRPassthroughLayer` | 1, sul root `OVRCameraRig` |
| `ISDKExampleMenu` | 1, root attivo |

I due oggetti `DistanceControllerHandGrabInteractor` contengono un componente della classe `Oculus.Interaction.HandGrab.DistanceHandGrabInteractor` insieme a `ControllerRef` e `InteractorControllerDecorator`: i nomi dei GameObject e i riferimenti controller li distinguono dalla route mani nude. Non sono stati aggiunti interactor.

### Riferimenti Passthrough/menu verificati nell’Inspector MCP

- `OVRCameraRig/OVRManager`: `isInsightPassthroughEnabled=true`, `requestScenePermissionOnStartup=false`, `requestPassthroughCameraAccessPermissionOnStartup=false`, `trackingOriginType=1`.
- `OVRCameraRig/OVRPassthroughLayer`: presente, `hidden=false`, `textureOpacity=1`, `edgeRenderingEnabled=false`.
- `ISDKExampleMenu/MRPassthrough._passThroughToggle` → `ToggleButton_Switch`.
- `ISDKExampleMenu/MRPassthrough._layer` → l’unico `OVRPassthroughLayer` del `OVRCameraRig` **nella copia**.
- `ISDKExampleMenu/MRPassthrough._camera` → `CenterEyeAnchor` **nella copia**.
- `ISDKExampleMenu/HmdRef._hmd` → `OVRHmd` **nella copia**.

Unity MCP ha verificato i riferimenti serializzati, non il funzionamento del toggle a runtime. L’insegnante aveva riferito in precedenza che lo switch VR/MR funzionava sul Quest; questa è evidenza storica, non un test eseguito in questa sessione.

### Scene Understanding non ancora pronto

La migrazione 209 non ha configurato MRUK e non lo fa automaticamente:

- `Assets/Oculus/OculusProjectConfig.asset`: `anchorSupport: 0` e `sceneSupport: 0`.
- Passthrough Support (`_insightPassthroughSupport`) è `1` (**Supported**), non `Required`.
- `OVRManager.requestScenePermissionOnStartup=false`.
- `Assets/Plugins/Android/AndroidManifest.xml` dichiara Passthrough come feature facoltativa e non include una dichiarazione Scene rilevata.

Questi sono prerequisiti da configurare e verificare in una fase successiva autorizzata; non bloccano la copia scena e qui non sono stati cambiati. MRUK e Scene Understanding non sono quindi ancora disponibili nel progetto.

## 4. Metodo di duplicazione e integrità

Ho usato Unity MCP `manage_asset(action="duplicate")` con:

```text
Sorgente:    Assets/Scenes/SampleScene.unity
Destinazione: Assets/Scenes/Lesson5_MixedReality.unity
Nuovo GUID:  153b4b9ccd99a4b4bb56d244490cc9bb
```

La scena sorgente ha GUID `99c9720ab356a0642a771bea13969a05`. I GUID sono distinti e Unity ha creato il `.meta` della copia. Il contenuto dei due file `.unity` è byte-identico (SHA-256 di entrambi: `73F8E0F5E887E3DA8101D15B2E0B4AA23AAD73456FCB29617D9334FFE33C7950`). Gli asset referenziati restano condivisi, come previsto; la nuova scena ha un’identità asset separata.

Ho aperto la copia tramite Unity MCP. La validazione `manage_scene(action="validate", auto_repair=false)` ha restituito: `totalIssues=0`, `missingScripts=0`, `brokenPrefabs=0`, `repaired=0`. Nessun autoripristino è stato eseguito.

Build Settings è rimasto invariato: `Assets/Scenes/SampleScene.unity` è ancora l’unica scena abilitata (build index 0); `Lesson5_MixedReality.unity` non è stata aggiunta.

## 5. Oggetti candidati da disattivare in seguito — nessuna modifica eseguita

Queste sono proposte per mantenere leggibile la futura scena MR. Prima di disattivarle, verificare eventuali riferimenti incrociati e decidere se l’attività MR deve mantenere le interazioni precedenti.

| Candidato nella copia L5 | Motivo possibile | Dipendenze / cautela |
|---|---|---|
| `Lesson4_AdvancedInteractions` (root) | Nascondere in blocco gli esercizi dimostrativi della Lezione 4, lasciando intatto il rig | Contiene `DistanceHandGrab_Exercise`, `L4_HandTrackingStatus`, `L4_GrabPose_Exercise`, `L4_ThumbsUp_Exercise`, `L4_TwoHanded_Exercise`, `L4_HandGrabUse_Exercise`, `L4_GrabSurface_Exercise`, `L4_Throw_Exercise`. Disattivarlo spegne indicatori e oggetti di prova; controllare prima eventuali riferimenti da UI/script esterni. La struttura rimane nella scena e si può riattivare. |
| `Environment/Table`, `Environment/Cube`, `Environment/Sphere`, `Environment/Cylinder` | Ridurre gli oggetti virtuali che possono coprire la stanza reale o distrarre dal demo MR | `Environment/Cube` è grabbable; la tabella contiene le parti del tavolo. Disattivarli rimuove anche interazioni di esempio legate agli oggetti. Preferire scelte puntuali, non disattivare subito l’intero `Environment`. |
| `Environment/SnapStation` e suoi figli | Rimuovere il banco di snap se non serve nella lezione MR | Il root ha `PowerCellTaskManager`; disattivarlo interrompe il task PowerCell/BatteryDock. Mantenerlo se si vuole fare regressione o confronto con la Lezione 2. |
| `ControlStation/ControlCanvas` | Possibile rimozione visiva dei controlli della lezione precedente quando esiste già un’interfaccia MR dedicata | Contiene Poke/Ray e interazione grab del pannello. Disattivarlo rompe il relativo esercizio UI; non disattivare il parent `ControlStation` senza valutare `TeleportHotspot_ControlStation`. |
| `FloorTeleportSurface`, `Environment/Floor`, `OVRCameraRig`, `ISDKExampleMenu`, `EventSystem` | **Non candidati per disattivazione iniziale** | Conservare pavimento/collider e teletrasporto finché la locomozione MR non è decisa; conservare rig, menu VR/MR e EventSystem per tracking, passthrough e input. Non è stato verificato se altri script richiedano i `HandLeft/Right PointerPose`; lasciarli attivi finché non se ne chiarisce la funzione nella scena L5. |

Non è stato disattivato né rimosso alcun GameObject.

## 6. Verifiche finali e limiti

- [x] Versioni Meta e XR effettivamente risolte consultate in Package Manager/manifest/lock.
- [x] Git iniziale controllato e nessuna modifica preesistente sovrascritta.
- [x] Scena originale attiva e salvata prima dell’operazione; sorgente verificata uguale a `HEAD`.
- [x] Nuova scena creata con GUID distinto, aperta via Unity MCP e validata senza autoriparazioni.
- [x] Gerarchia di 12 radici, conteggi dei componenti principali e riferimenti passthrough/menu verificati nella copia.
- [x] Build Settings controllato e lasciato invariato.
- [x] Nessun errore Console al gate pre-duplicazione; compilation non in corso.
- [x] Validazione copia senza missing script/prefab broken; un log Error successivo è stato generato dal getter nativo `OVRManager.nativeColorGamut` durante la serializzazione MCP (vedi sopra).
- [ ] I due fix Meta “Recommended” non sono stati aperti o applicati.
- [ ] Il warning di nome `CharacterController` non è stato ricondotto a un sorgente.
- [ ] Nessuna build, Play Mode, deploy o prova Quest eseguita; interazioni e passthrough non sono stati ritestati dopo la migrazione.
- [ ] MRUK, Scene Support, permessi Scene e manifest Scene restano da configurare in seguito.

**Stato conclusivo:** SDK Meta 209 risolto; nessun errore di compilazione osservato. La scena L5 è duplicata e verificata staticamente. La Console contiene inoltre un log Error generato durante l’ispezione MCP di `OVRManager.nativeColorGamut`, di origine nativa non chiarita ma distinto dagli errori di compilazione. Restano le due raccomandazioni Meta e il warning `CharacterController` non attribuito. La copia non è inclusa nei Build Settings e non è ancora una scena MRUK funzionante.
