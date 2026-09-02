using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005883 RID: 22659
	[NullableContext(1)]
	[Nullable(0)]
	public class SoundBoxMarkItemView : ServerMarkItemView
	{
		// Token: 0x060399AE RID: 235950 RVA: 0x00E9CE94 File Offset: 0x00E9B094
		public SoundBoxMarkItemView(SoundBoxMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060399AF RID: 235951 RVA: 0x00E9CEA0 File Offset: 0x00E9B0A0
		protected override UniTask OnCreateAsync()
		{
			SoundBoxMarkItemView.<OnCreateAsync>d__3 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<SoundBoxMarkItemView.<OnCreateAsync>d__3>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060399B0 RID: 235952 RVA: 0x00E9CEE3 File Offset: 0x00E9B0E3
		protected override void OnStart()
		{
			this.RadarEffect.SetUIParent(base.GetRootItem(), false);
			base.OnStart();
		}

		// Token: 0x060399B1 RID: 235953 RVA: 0x00E9CEFD File Offset: 0x00E9B0FD
		protected override void OnViewRefresh()
		{
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x060399B2 RID: 235954 RVA: 0x00E9CF10 File Offset: 0x00E9B110
		protected override void OnSafeUpdate(Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			int? soundBoxEntityId = ((SoundBoxMarkItem)this.Holder).GetSoundBoxEntityId();
			if (soundBoxEntityId != null)
			{
				object entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(soundBoxEntityId.Value);
				this.SwitchSleepState(entityByPbDataId == null);
			}
		}

		// Token: 0x060399B3 RID: 235955 RVA: 0x00E9CF54 File Offset: 0x00E9B154
		public void SwitchSleepState(bool isSleep)
		{
			if (this.IsSleepState == isSleep)
			{
				return;
			}
			this.IsSleepState = isSleep;
			if (isSleep)
			{
				this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(isSleep ? "SP_MarkSleep" : "SP_MarkNormal"), base.GetSprite(2), false, null, null);
				base.GetSprite(2).SetUIActive(true);
				return;
			}
			base.GetSprite(2).SetUIActive(false);
		}

		// Token: 0x060399B4 RID: 235956 RVA: 0x00E9CFC1 File Offset: 0x00E9B1C1
		public override bool GetInteractiveFlag()
		{
			return false;
		}

		// Token: 0x060399B5 RID: 235957 RVA: 0x00E9CFC4 File Offset: 0x00E9B1C4
		protected override void OnBeforeDestroy()
		{
			if (this.RadarEffect != null)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.RadarEffect.GetOwner(), true);
			}
			this.RadarEffect = null;
			base.OnBeforeDestroy();
		}

		// Token: 0x04020AD9 RID: 133849
		[Nullable(2)]
		private UUIItem RadarEffect;

		// Token: 0x04020ADA RID: 133850
		private bool IsSleepState;
	}
}
