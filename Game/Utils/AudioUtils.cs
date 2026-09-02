using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046F2 RID: 18162
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AudioUtils : Singleton<AudioUtils>
	{
		// Token: 0x0602F3C9 RID: 193481 RVA: 0x00B330FC File Offset: 0x00B312FC
		public void HandleAudioBoxUpdate(AudioBox box, EAudioUpdateType type)
		{
			AudioBox audioBox = ModelBase<AudioModel>.Instance.UpdateAudioBoxQueue(box, type);
			if (audioBox == null)
			{
				return;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(audioBox.PbDataId);
			if (entityByPbDataId == null)
			{
				return;
			}
			SceneItemStateAudioComponent component = entityByPbDataId.Entity.GetComponent<SceneItemStateAudioComponent>();
			if (component == null)
			{
				return;
			}
			component.PostAudioBoxEvent();
		}

		// Token: 0x0602F3CA RID: 193482 RVA: 0x00B33148 File Offset: 0x00B31348
		public FoliageAudioInfo QueryFoliageAudioPhysicalMaterial(FVectorDouble location, [Nullable(2)] Entity entity = null)
		{
			FoliageAudioInfo foliageAudioInfo = new FoliageAudioInfo();
			UKuroAudioMaterialSubsystem ukuroAudioMaterialSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroAudioMaterialSubsystem.StaticClass()) as UKuroAudioMaterialSubsystem;
			FName none = FNameUtil.NONE;
			UPhysicalMaterial physicalMaterial = null;
			UStaticMeshComponent ustaticMeshComponent = null;
			foliageAudioInfo.IsHitFoliage = ukuroAudioMaterialSubsystem.QueryInsideAnyFoliageInstance(location, ref none, ref physicalMaterial, ref ustaticMeshComponent);
			UStaticMeshComponent ustaticMeshComponent2 = ustaticMeshComponent;
			if (ustaticMeshComponent2 != null && ustaticMeshComponent2.IsValid())
			{
				if (!ustaticMeshComponent2.bHiddenInGame)
				{
					AActor owner = ustaticMeshComponent2.GetOwner();
					if (owner == null || !owner.bHidden)
					{
						goto IL_76;
					}
				}
				foliageAudioInfo.IsHitFoliage = false;
				return foliageAudioInfo;
			}
			IL_76:
			foliageAudioInfo.FoliageName = none;
			foliageAudioInfo.PhysicalMaterial = physicalMaterial;
			string text = none.ToString();
			if (text.Contains("_Shr_") || text.Contains("_Veg_"))
			{
				foliageAudioInfo.IsAudioShrub = true;
			}
			if (ustaticMeshComponent2 != null && ustaticMeshComponent2.IsValid())
			{
				UStaticMesh staticMesh = ustaticMeshComponent2.StaticMesh;
				if (staticMesh != null && staticMesh.IsValid())
				{
					for (int i = 0; i < ustaticMeshComponent2.StaticMesh.Tags.Num(); i++)
					{
						string text2 = ustaticMeshComponent2.StaticMesh.Tags.Get(i).ToString();
						if (text2.StartsWith("Audio_"))
						{
							foliageAudioInfo.AudioShrubTag = new FName(text2.Substring("Audio_".Length));
						}
					}
				}
			}
			if (entity != null)
			{
				RoleAudioComponent component = entity.GetComponent<RoleAudioComponent>();
				if (component != null)
				{
					component.UpdateIsInAudioShrubEvent(foliageAudioInfo.IsAudioShrub, foliageAudioInfo.AudioShrubTag);
				}
			}
			return foliageAudioInfo;
		}

		// Token: 0x0401AE8F RID: 110223
		private const string AUDIO_TAG_PREFIX = "Audio_";
	}
}
