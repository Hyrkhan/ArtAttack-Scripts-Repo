using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SkillAnimation : MonoBehaviour
{
    public bool Skill1 = true;
    public bool guard = false;
    public Button guardButton;  // assign this in the Inspector

    private float timer = 0f;
    public Animator animator;
    public PlayerMovement playerMovement;

    public GameObject SlashObject;
    public float spawnInterval = 0.3f;
    public float waitTime = 0.4f;

    public float cooldownTime = 6f;
    public AudioSource Skill1sound;

    public void UseSkill1()
    {
        if (Skill1) // Only use the skill if it is available
        {
            Skill1 = false; // Set the skill to unavailable
            timer = cooldownTime; // Start the cooldown timer
            StartCoroutine(ActivateSkill()); // Activate the skill after the cooldown timer
        }
    }

    private IEnumerator ActivateSkill()
    {
        // Play the animation and activate the skill
        animator.SetBool("Skill_1", true);
        playerMovement.SetSkillActive(true);

        // Play the sound loop
        Skill1sound.loop = true;
        Skill1sound.Play();

        // Wait for the animation to finish
        yield return new WaitForSeconds(waitTime);

        // Spawn the slash objects
        for (int i = 0; i < 3; i++)
        {
            Instantiate(SlashObject, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }

        // Stop the sound loop
        Skill1sound.Stop();
        Skill1sound.loop = false;

        // Deactivate the skill and reset the animation parameter
        playerMovement.SetSkillActive(false);
        animator.SetBool("Skill_1", false);
    }

    void Start()
    {
        // Add the EventTrigger component to the guardButton GameObject
        EventTrigger trigger = guardButton.gameObject.AddComponent<EventTrigger>();

        // Create a new entry for the pointer down event
        EventTrigger.Entry pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(pointerDown);

        // Create a new entry for the pointer up event
        EventTrigger.Entry pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        trigger.triggers.Add(pointerUp);
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        // When the pointer is pressed, set the guard variable to true
        // and update the animator and player movement components
        guard = true;
        animator.SetBool("Guarding", guard);
        playerMovement.SetSkillActive(guard);
    }

    public void OnPointerUpDelegate(PointerEventData data)
    {
        // When the pointer is released, set the guard variable to false
        // and update the animator and player movement components
        guard = false;
        animator.SetBool("Guarding", guard);
        playerMovement.SetSkillActive(guard);
    }

    void Update()
    {
        if (!Skill1) // Only start counting down if the skill is on cooldown
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Skill1 = true; // Set the skill to available
            }
        }
    }
}
