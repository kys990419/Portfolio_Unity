using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyBtnClick : MonoBehaviour
{
    public UI ui;
    public PlayerMove playerMove;
    public GameObject KeyInven;
    public GameObject StartScene;
    public void getBtn()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[47]);
        KeyInven.gameObject.SetActive(true);
    }
    public void OutBtn()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[47]);
        KeyInven.gameObject.SetActive(false);
        WeaponInven.WeaponyActivated = false;
        PortionInven.PortionInvenActivated = false;
        ArmorInven.ArmorActivated = false;
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void GameStartBtn()
    {
        StartCoroutine("goTown");
    }
    IEnumerator goTown()
    {
        yield return new WaitForSeconds(1f);
        ui.Fade();
        yield return new WaitForSeconds(1f);
        SoundManager.instace.bgSound.Stop();
        yield return new WaitForSeconds(1f);
        playerMove.startGame = true;
        StartScene.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
    }
}