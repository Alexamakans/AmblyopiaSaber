﻿using AmblyopiaSaber.Config;
using AmblyopiaSaber.Utils;
using SiraUtil.Objects;
using UnityEngine;
using Zenject;

namespace AmblyopiaSaber.Data
{
    public class AmblyopiaController : MonoBehaviour, INoteControllerNoteWasCutEvent, INoteControllerNoteWasMissedEvent, INoteControllerDidInitEvent, INoteControllerNoteDidDissolveEvent
    {
        private PluginConfig _pluginConfig;

        protected Transform noteCube;
        private GameNoteController _gameNoteController;
        // private CustomNoteColorNoteVisuals _customNoteColorNoteVisuals;

        protected GameObject activeNote;
        protected SiraPrefabContainer container;
        protected SiraPrefabContainer.Pool activePool;

        [Inject]
        internal void Init(PluginConfig pluginConfig)
        {
            _pluginConfig = pluginConfig;
            gameObject.GetComponent<ColorNoteVisuals>().didInitEvent += AmblyopiaController_didInitEvent;
            _gameNoteController = GetComponent<GameNoteController>();

            _gameNoteController.didInitEvent.Add(this);
            _gameNoteController.noteWasCutEvent.Add(this);
            _gameNoteController.noteWasMissedEvent.Add(this);
            _gameNoteController.noteDidDissolveEvent.Add(this);

            noteCube = _gameNoteController.gameObject.transform.Find("NoteCube");
        }

        private void AmblyopiaController_didInitEvent(ColorNoteVisuals arg1, NoteControllerBase noteController)
        {

        }

        public void HandleNoteControllerNoteWasMissed(NoteController nc)
        {

        }

        public void HandleNoteControllerDidInit(NoteControllerBase noteController)
        {
            NoteUtils.ApplyConfigToNote(_pluginConfig, noteController, false);
        }

        public void HandleNoteControllerNoteWasCut(NoteController nc, in NoteCutInfo _)
        {
            HandleNoteControllerNoteWasMissed(nc);
        }

        public void HandleNoteControllerNoteDidDissolve(NoteController noteController)
        {
            HandleNoteControllerNoteWasMissed(noteController);
        }


    }
}
