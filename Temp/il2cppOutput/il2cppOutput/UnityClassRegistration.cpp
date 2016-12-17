struct ClassRegistrationContext;
void InvokeRegisterStaticallyLinkedModuleClasses(ClassRegistrationContext& context)
{
	// Do nothing (we're in stripping mode)
}

void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_CloudWebServices();
	RegisterModule_CloudWebServices();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_UnityConnect();
	RegisterModule_UnityConnect();

	void RegisterModule_UnityWebRequest();
	RegisterModule_UnityWebRequest();

}

void RegisterAllClasses()
{
	//Total: 63 classes
	//0. GUILayer
	void RegisterClass_GUILayer();
	RegisterClass_GUILayer();

	//1. Behaviour
	void RegisterClass_Behaviour();
	RegisterClass_Behaviour();

	//2. Component
	void RegisterClass_Component();
	RegisterClass_Component();

	//3. EditorExtension
	void RegisterClass_EditorExtension();
	RegisterClass_EditorExtension();

	//4. Texture
	void RegisterClass_Texture();
	RegisterClass_Texture();

	//5. NamedObject
	void RegisterClass_NamedObject();
	RegisterClass_NamedObject();

	//6. Texture2D
	void RegisterClass_Texture2D();
	RegisterClass_Texture2D();

	//7. NetworkView
	void RegisterClass_NetworkView();
	RegisterClass_NetworkView();

	//8. RectTransform
	void RegisterClass_RectTransform();
	RegisterClass_RectTransform();

	//9. Transform
	void RegisterClass_Transform();
	RegisterClass_Transform();

	//10. Camera
	void RegisterClass_Camera();
	RegisterClass_Camera();

	//11. MonoBehaviour
	void RegisterClass_MonoBehaviour();
	RegisterClass_MonoBehaviour();

	//12. GameObject
	void RegisterClass_GameObject();
	RegisterClass_GameObject();

	//13. Rigidbody2D
	void RegisterClass_Rigidbody2D();
	RegisterClass_Rigidbody2D();

	//14. AudioClip
	void RegisterClass_AudioClip();
	RegisterClass_AudioClip();

	//15. SampleClip
	void RegisterClass_SampleClip();
	RegisterClass_SampleClip();

	//16. Animator
	void RegisterClass_Animator();
	RegisterClass_Animator();

	//17. DirectorPlayer
	void RegisterClass_DirectorPlayer();
	RegisterClass_DirectorPlayer();

	//18. Collider2D
	void RegisterClass_Collider2D();
	RegisterClass_Collider2D();

	//19. PreloadData
	void RegisterClass_PreloadData();
	RegisterClass_PreloadData();

	//20. Material
	void RegisterClass_Material();
	RegisterClass_Material();

	//21. Cubemap
	void RegisterClass_Cubemap();
	RegisterClass_Cubemap();

	//22. Texture3D
	void RegisterClass_Texture3D();
	RegisterClass_Texture3D();

	//23. Texture2DArray
	void RegisterClass_Texture2DArray();
	RegisterClass_Texture2DArray();

	//24. RenderTexture
	void RegisterClass_RenderTexture();
	RegisterClass_RenderTexture();

	//25. Mesh
	void RegisterClass_Mesh();
	RegisterClass_Mesh();

	//26. LevelGameManager
	void RegisterClass_LevelGameManager();
	RegisterClass_LevelGameManager();

	//27. GameManager
	void RegisterClass_GameManager();
	RegisterClass_GameManager();

	//28. TimeManager
	void RegisterClass_TimeManager();
	RegisterClass_TimeManager();

	//29. GlobalGameManager
	void RegisterClass_GlobalGameManager();
	RegisterClass_GlobalGameManager();

	//30. AudioManager
	void RegisterClass_AudioManager();
	RegisterClass_AudioManager();

	//31. InputManager
	void RegisterClass_InputManager();
	RegisterClass_InputManager();

	//32. Physics2DSettings
	void RegisterClass_Physics2DSettings();
	RegisterClass_Physics2DSettings();

	//33. Renderer
	void RegisterClass_Renderer();
	RegisterClass_Renderer();

	//34. GraphicsSettings
	void RegisterClass_GraphicsSettings();
	RegisterClass_GraphicsSettings();

	//35. QualitySettings
	void RegisterClass_QualitySettings();
	RegisterClass_QualitySettings();

	//36. Shader
	void RegisterClass_Shader();
	RegisterClass_Shader();

	//37. TextAsset
	void RegisterClass_TextAsset();
	RegisterClass_TextAsset();

	//38. BoxCollider2D
	void RegisterClass_BoxCollider2D();
	RegisterClass_BoxCollider2D();

	//39. AnimationClip
	void RegisterClass_AnimationClip();
	RegisterClass_AnimationClip();

	//40. Motion
	void RegisterClass_Motion();
	RegisterClass_Motion();

	//41. TagManager
	void RegisterClass_TagManager();
	RegisterClass_TagManager();

	//42. AudioListener
	void RegisterClass_AudioListener();
	RegisterClass_AudioListener();

	//43. AudioBehaviour
	void RegisterClass_AudioBehaviour();
	RegisterClass_AudioBehaviour();

	//44. AnimatorController
	void RegisterClass_AnimatorController();
	RegisterClass_AnimatorController();

	//45. RuntimeAnimatorController
	void RegisterClass_RuntimeAnimatorController();
	RegisterClass_RuntimeAnimatorController();

	//46. ScriptMapper
	void RegisterClass_ScriptMapper();
	RegisterClass_ScriptMapper();

	//47. DelayedCallManager
	void RegisterClass_DelayedCallManager();
	RegisterClass_DelayedCallManager();

	//48. RenderSettings
	void RegisterClass_RenderSettings();
	RegisterClass_RenderSettings();

	//49. MonoScript
	void RegisterClass_MonoScript();
	RegisterClass_MonoScript();

	//50. MonoManager
	void RegisterClass_MonoManager();
	RegisterClass_MonoManager();

	//51. FlareLayer
	void RegisterClass_FlareLayer();
	RegisterClass_FlareLayer();

	//52. PlayerSettings
	void RegisterClass_PlayerSettings();
	RegisterClass_PlayerSettings();

	//53. BuildSettings
	void RegisterClass_BuildSettings();
	RegisterClass_BuildSettings();

	//54. ResourceManager
	void RegisterClass_ResourceManager();
	RegisterClass_ResourceManager();

	//55. NetworkManager
	void RegisterClass_NetworkManager();
	RegisterClass_NetworkManager();

	//56. MasterServerInterface
	void RegisterClass_MasterServerInterface();
	RegisterClass_MasterServerInterface();

	//57. LightmapSettings
	void RegisterClass_LightmapSettings();
	RegisterClass_LightmapSettings();

	//58. SpriteRenderer
	void RegisterClass_SpriteRenderer();
	RegisterClass_SpriteRenderer();

	//59. Sprite
	void RegisterClass_Sprite();
	RegisterClass_Sprite();

	//60. RuntimeInitializeOnLoadManager
	void RegisterClass_RuntimeInitializeOnLoadManager();
	RegisterClass_RuntimeInitializeOnLoadManager();

	//61. CloudWebServicesManager
	void RegisterClass_CloudWebServicesManager();
	RegisterClass_CloudWebServicesManager();

	//62. UnityConnectSettings
	void RegisterClass_UnityConnectSettings();
	RegisterClass_UnityConnectSettings();

}
