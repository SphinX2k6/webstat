using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection
{
	// Token: 0x02004525 RID: 17701
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixNetworkDetectionTips : LaunchComponentsAction
	{
		// Token: 0x0602EA06 RID: 190982 RVA: 0x00B0B841 File Offset: 0x00B09A41
		public void InitTickManager(UObject worldContext, string tickName)
		{
			this.TickManager = new UKuroTickManager(worldContext, tickName, EObjectFlags.RF_NoFlags);
		}

		// Token: 0x0602EA07 RID: 190983 RVA: 0x00B0B851 File Offset: 0x00B09A51
		protected override void OnShow()
		{
			this.SetTextureIconActive(true);
			HotFixSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlaySequence("Loop", null);
		}

		// Token: 0x0602EA08 RID: 190984 RVA: 0x00B0B871 File Offset: 0x00B09A71
		protected override void OnBeforeDestroy()
		{
			if (this.TickManager != null)
			{
				this.RemoveTickDelegate();
				this.TickManager = null;
			}
		}

		// Token: 0x0602EA09 RID: 190985 RVA: 0x00B0B888 File Offset: 0x00B09A88
		public void SetTextureIconActive(bool active)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(active);
		}

		// Token: 0x0602EA0A RID: 190986 RVA: 0x00B0B89C File Offset: 0x00B09A9C
		public void SetTipsText(string text)
		{
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x0602EA0B RID: 190987 RVA: 0x00B0B8B1 File Offset: 0x00B09AB1
		public void SetTipsLocalText(string textKey)
		{
			HotFixManager.SetLocalText(base.GetText(0), textKey, Array.Empty<string>());
		}

		// Token: 0x0602EA0C RID: 190988 RVA: 0x00B0B8C8 File Offset: 0x00B09AC8
		public void ShowTip(string textKey)
		{
			this.SetTipsLocalText(textKey);
			base.SetActive(true);
			this.SetTextureIconActive(false);
			this.RemoveTickDelegate();
			this.TickDelegate = new Action<float>(this.TickCallback);
			this.TickManager.AddTick(ETickingGroup.TG_PrePhysics, global::DelegateUtils.ToManualReleaseDelegate<FTickHandler>(this.TickDelegate), 0);
		}

		// Token: 0x0602EA0D RID: 190989 RVA: 0x00B0B91B File Offset: 0x00B09B1B
		private void TickCallback(float delta)
		{
			this.TickTimeSinceStartup += (double)delta;
			if (this.TickTimeSinceStartup > 1.2)
			{
				base.SetActive(false);
				this.RemoveTickDelegate();
			}
		}

		// Token: 0x0602EA0E RID: 190990 RVA: 0x00B0B94A File Offset: 0x00B09B4A
		private void RemoveTickDelegate()
		{
			if (this.TickDelegate != null)
			{
				this.TickManager.RemoveTick(ETickingGroup.TG_PrePhysics);
				global::DelegateUtils.ReleaseManualReleaseDelegate(this.TickDelegate);
				this.TickDelegate = null;
			}
			this.TickTimeSinceStartup = -1.0;
		}

		// Token: 0x0401A7A9 RID: 108457
		[Nullable(2)]
		private UKuroTickManager TickManager;

		// Token: 0x0401A7AA RID: 108458
		[Nullable(2)]
		private Action<float> TickDelegate;

		// Token: 0x0401A7AB RID: 108459
		private double TickTimeSinceStartup;

		// Token: 0x0200A73E RID: 42814
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04033E80 RID: 212608
			public const int TxtTips = 0;

			// Token: 0x04033E81 RID: 212609
			public const int TexIcon = 1;
		}
	}
}
