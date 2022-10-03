
using UnityEngine;

public enum LevelType { Loader, GameplayScene, MainMenu }
public enum CardSortingLayer { Card1, Card2, Card3, Card4, Card5, Card6, Card7, Card8, Card9, HighlightedCard }
public enum AttributeType { None, MaxHp, CurrentHp, MaxCardsInHand, Damage, Poison, Block, CurrentDamage }

public enum EncounterDifficulty { Easy, Medium, Hard }

public enum SoundType { Slash, Death, MenuButton }

public class Globals
{
	public const string MouseOverCardAnimBool = "MouseOver";
	public const string EnemyAttackAnimTrigger = "Attack";
	public const string WaveHighscoreKey = "Highscore";

    public static int GetHighscore()
    {
        int highscore = 0;

        if (PlayerPrefs.HasKey(WaveHighscoreKey))
        {
            return PlayerPrefs.GetInt(WaveHighscoreKey);
        }

        return highscore;
    }

    public static void SaveNewHighscore(int newScore)
    {
        PlayerPrefs.SetInt(WaveHighscoreKey, newScore);
    }
}