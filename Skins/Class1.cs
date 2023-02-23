using MelonLoader;
using UnityEngine;

namespace Skins
{
	public class Class1 : MelonMod
	{
		public byte[] Bytes;
		public TextAsset TextAsset;

		public bool hasWall;
		public bool hasPillar;
		public bool hasCube;
		public bool hasBall;
		public bool hasDisc;
		public bool hasPlayer;
		
		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			Texture2D pillarTexture = new Texture2D(2, 2);
			if (System.IO.File.Exists(MelonUtils.UserDataDirectory + "/Skins/Pillar/skin.png"))
			{
				hasPillar = true;
				Bytes = System.IO.File.ReadAllBytes(MelonUtils.UserDataDirectory + "/Skins/Pillar/skin.png");
				ImageConversion.LoadImage(pillarTexture, Bytes);
			}
			
			Texture2D wallTexture = new Texture2D(2, 2);
			if (System.IO.File.Exists(MelonUtils.UserDataDirectory + "/Skins/Wall/skin.png"))
			{
				hasWall = true;
				Bytes = System.IO.File.ReadAllBytes(MelonUtils.UserDataDirectory + "/Skins/Wall/skin.png");
				ImageConversion.LoadImage(wallTexture, Bytes);
			}
			
			Texture2D discTexture = new Texture2D(2, 2);
			if (System.IO.File.Exists(MelonUtils.UserDataDirectory + "/Skins/Disc/skin.png"))
			{
				hasDisc = true;
				Bytes = System.IO.File.ReadAllBytes(MelonUtils.UserDataDirectory + "/Skins/Disc/skin.png");
				ImageConversion.LoadImage(discTexture, Bytes);
			}
			
			Texture2D cubeTexture = new Texture2D(2, 2);
			if (System.IO.File.Exists(MelonUtils.UserDataDirectory + "/Skins/Cube/skin.png"))
			{
				hasCube = true;
				Bytes = System.IO.File.ReadAllBytes(MelonUtils.UserDataDirectory + "/Skins/Cube/skin.png");
				ImageConversion.LoadImage(cubeTexture, Bytes);
			}
			
			Texture2D ballTexture = new Texture2D(2, 2);
			if (System.IO.File.Exists(MelonUtils.UserDataDirectory + "/Skins/Ball/skin.png"))
			{
				hasBall = true;
				Bytes = System.IO.File.ReadAllBytes(MelonUtils.UserDataDirectory + "/Skins/Ball/skin.png");
				ImageConversion.LoadImage(ballTexture, Bytes);
			}
			
			Texture2D playerTexture = new Texture2D(2, 2);
			if (System.IO.File.Exists(MelonUtils.UserDataDirectory + "/Skins/Player/skin.png"))
			{
				hasPlayer = true;
				Bytes = System.IO.File.ReadAllBytes(MelonUtils.UserDataDirectory + "/Skins/Player/skin.png");
				ImageConversion.LoadImage(playerTexture, Bytes);
			}

			foreach (MeshRenderer meshRenderer in Resources.FindObjectsOfTypeAll<MeshRenderer>())
			{
				if (meshRenderer.transform.parent != null)
				{
					if (meshRenderer.transform.parent.name == "Pillar")
					{
						if (hasPillar)
						{
							MelonLogger.Msg("Applying new texture");
							foreach (var property in meshRenderer.material.GetTexturePropertyNames())
							{
								meshRenderer.material.SetTexture(property, pillarTexture);
							}
						}
					}
					else if (meshRenderer.transform.parent.name == "Disc")
					{
						if (hasDisc)
						{
							MelonLogger.Msg("Applying new texture");
							foreach (var property in meshRenderer.material.GetTexturePropertyNames())
							{
								meshRenderer.material.SetTexture(property, discTexture);
							}
						}
					}
					else if (meshRenderer.transform.parent.name == "Wall")
					{
						if (hasWall)
						{
							MelonLogger.Msg("Applying new texture");
							foreach (var property in meshRenderer.material.GetTexturePropertyNames())
							{
								meshRenderer.material.SetTexture(property, wallTexture);
							}
						}
					}
					else if (meshRenderer.transform.parent.name == "RockCube")
					{
						if (hasCube)
						{
							MelonLogger.Msg("Applying new texture");
							foreach (var property in meshRenderer.material.GetTexturePropertyNames())
							{
								meshRenderer.material.SetTexture(property, cubeTexture);
							}
						}
					}
					else if (meshRenderer.transform.parent.name == "Ball")
					{
						if (hasBall)
						{
							MelonLogger.Msg("Applying new texture");
							foreach (var property in meshRenderer.material.GetTexturePropertyNames())
							{
								meshRenderer.material.SetTexture(property, ballTexture);
							}
						}
					}
				}
			}

			foreach (SkinnedMeshRenderer skinnedMeshRenderer in Resources.FindObjectsOfTypeAll<SkinnedMeshRenderer>())
			{
				if (skinnedMeshRenderer.transform.parent != null)
				{
					if (skinnedMeshRenderer.gameObject.name.Contains("Suit") && hasPlayer)
					{
						MelonLogger.Msg("Applying new texture");
						foreach (var property in skinnedMeshRenderer.material.GetTexturePropertyNames())
						{
							skinnedMeshRenderer.material.SetTexture(property, playerTexture);
						}
					}
				}
			}
		}
	}
}