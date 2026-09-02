using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004751 RID: 18257
	[NullableContext(2)]
	[Nullable(0)]
	public class CharSceneInteraction : CharRenderBase
	{
		// Token: 0x0602F606 RID: 194054 RVA: 0x00B3D2C4 File Offset: 0x00B3B4C4
		public override void Start()
		{
			base.Start();
			this.OwnerCharacter = (this.RenderComponent.GetOwner() as TsBaseCharacter);
			this.CharacterInteraction = null;
			this.PossCharacter(this.RenderComponent.InteractionConfig, 1f);
			base.OnInitSuccess();
		}

		// Token: 0x0602F607 RID: 194055 RVA: 0x00B3D310 File Offset: 0x00B3B510
		public override void Update()
		{
			if (this.CharacterInteraction != null)
			{
				this.CharacterInteraction.Update(base.GetDeltaTime());
			}
		}

		// Token: 0x0602F608 RID: 194056 RVA: 0x00B3D32B File Offset: 0x00B3B52B
		public override void Destroy()
		{
			this.UnpossCharacter();
			base.Destroy();
		}

		// Token: 0x0602F609 RID: 194057 RVA: 0x00B3D339 File Offset: 0x00B3B539
		public bool GetIsPossed()
		{
			return this.CharacterInteraction != null;
		}

		// Token: 0x0602F60A RID: 194058 RVA: 0x00B3D344 File Offset: 0x00B3B544
		public void PossCharacter(PDA_InteractionPlayerConfig_C config, float updateInternalScale = 1f)
		{
			if (config == null)
			{
				return;
			}
			if (this.OwnerCharacter != null)
			{
				this.CharacterInteraction = new SceneCharacterInteraction();
				this.CharacterInteraction.Start(this.OwnerCharacter, config, updateInternalScale);
			}
		}

		// Token: 0x0602F60B RID: 194059 RVA: 0x00B3D370 File Offset: 0x00B3B570
		public void UnpossCharacter()
		{
			if (this.CharacterInteraction != null)
			{
				this.CharacterInteraction.Destroy();
				this.CharacterInteraction = null;
			}
		}

		// Token: 0x0602F60C RID: 194060 RVA: 0x00B3D38C File Offset: 0x00B3B58C
		public override int GetComponentId()
		{
			return 5;
		}

		// Token: 0x0602F60D RID: 194061 RVA: 0x00B3D38F File Offset: 0x00B3B58F
		[NullableContext(1)]
		public override string GetStatName()
		{
			return "CharSceneInteraction";
		}

		// Token: 0x0602F60E RID: 194062 RVA: 0x00B3D396 File Offset: 0x00B3B596
		public bool GetInWater(float depthThreshold)
		{
			return this.CharacterInteraction != null && this.CharacterInteraction.GetInWater() && this.CharacterInteraction.GetWaterDepth() > (double)depthThreshold;
		}

		// Token: 0x0602F60F RID: 194063 RVA: 0x00B3D3C0 File Offset: 0x00B3B5C0
		public double GetWaterHitLocationZ()
		{
			if (this.CharacterInteraction != null)
			{
				return this.CharacterInteraction.GetWaterHitLocationZ();
			}
			return 0.0;
		}

		// Token: 0x0602F610 RID: 194064 RVA: 0x00B3D3DF File Offset: 0x00B3B5DF
		public bool GetInAudioShr()
		{
			return this.CharacterInteraction != null && this.CharacterInteraction.GetInAudioShr();
		}

		// Token: 0x0602F611 RID: 194065 RVA: 0x00B3D3F6 File Offset: 0x00B3B5F6
		public FName GetAudioShrTag()
		{
			if (this.CharacterInteraction != null)
			{
				return this.CharacterInteraction.GetAudioShrTag();
			}
			return FNameUtil.NONE;
		}

		// Token: 0x0401AF9F RID: 110495
		protected TsBaseCharacter OwnerCharacter;

		// Token: 0x0401AFA0 RID: 110496
		protected SceneCharacterInteraction CharacterInteraction;
	}
}
