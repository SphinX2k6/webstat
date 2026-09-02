using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200611C RID: 24860
	public class TopBuffItem : UiPanelBase
	{
		// Token: 0x0603ECC8 RID: 257224 RVA: 0x01014F70 File Offset: 0x01013170
		public override void SetActive(bool visibility)
		{
			if (this.GetVisible() != visibility)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "不要直接调用SetActive, 请调用SetVisible", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			base.SetActive(visibility);
		}

		// Token: 0x0603ECC9 RID: 257225 RVA: 0x01014FAC File Offset: 0x010131AC
		public void SetVisible(int visibleReason, bool bVisible)
		{
			bool visible = this.GetVisible();
			this.SetVisibleInner(visibleReason, bVisible);
			bool visible2 = this.GetVisible();
			if (visible == visible2)
			{
				return;
			}
			this.SetActive(visible2);
		}

		// Token: 0x0603ECCA RID: 257226 RVA: 0x01014FD9 File Offset: 0x010131D9
		private void SetVisibleInner(int visibleReason, bool bVisible)
		{
			this.InnerVisibleState = VisibleStateUtil.SetVisible(this.InnerVisibleState, bVisible, visibleReason);
		}

		// Token: 0x0603ECCB RID: 257227 RVA: 0x01014FEE File Offset: 0x010131EE
		public bool GetVisible()
		{
			return this.InnerVisibleState == 0;
		}

		// Token: 0x0603ECCC RID: 257228 RVA: 0x01014FF9 File Offset: 0x010131F9
		protected void InitTweenAnim(int componentType)
		{
			if (this.TweenAnimPlayer == null)
			{
				this.TweenAnimPlayer = new BattleUiTweenAnimPlayer();
			}
			this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
		}

		// Token: 0x0603ECCD RID: 257229 RVA: 0x01015022 File Offset: 0x01013222
		protected void PlayTweenAnim(int componentType)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.PlayTweenAnim(componentType);
		}

		// Token: 0x0603ECCE RID: 257230 RVA: 0x01015035 File Offset: 0x01013235
		protected void StopTweenAnim(int componentType)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.StopTweenAnim(componentType);
		}

		// Token: 0x0603ECCF RID: 257231 RVA: 0x01015048 File Offset: 0x01013248
		protected void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.Clear(false);
		}

		// Token: 0x0603ECD0 RID: 257232 RVA: 0x0101505B File Offset: 0x0101325B
		protected void SetTweenTimeScale(int componentType, float timeScale)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.SetTweenTimeScale(componentType, timeScale);
		}

		// Token: 0x0402338E RID: 144270
		protected int InnerVisibleState = 1;

		// Token: 0x0402338F RID: 144271
		[Nullable(2)]
		protected BattleUiTweenAnimPlayer TweenAnimPlayer;
	}
}
