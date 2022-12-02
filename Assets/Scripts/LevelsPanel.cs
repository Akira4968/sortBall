
using System.Collections.Generic;
using System.Linq;
using dotmob;
using UnityEngine;

public class LevelsPanel : ShowHidable
{
    [SerializeField] private LevelTileUI _levelTileUIPrefab;
    [SerializeField] private RectTransform _content;

    



    private readonly List<LevelTileUI> _tiles = new List<LevelTileUI>();


    private void LevelTileUIOnClicked(LevelTileUI tileUI)
    {
        if (tileUI.MViewModel.Locked)
        {
            return;
        }

        GameManager.LoadGame(new LoadGameData
        {
            Level = tileUI.MViewModel.Level
        });
    }
}