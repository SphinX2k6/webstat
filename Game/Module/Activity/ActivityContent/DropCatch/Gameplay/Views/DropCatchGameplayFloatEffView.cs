using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x020068FE RID: 26878
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayFloatEffView : DropCatchGameplayPoolPanelBase
	{
		// Token: 0x06042C68 RID: 273512 RVA: 0x011230E8 File Offset: 0x011212E8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIArtText))
			};
		}

		// Token: 0x06042C69 RID: 273513 RVA: 0x01123184 File Offset: 0x01121384
		protected override void OnStart()
		{
			this.PosDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenVector2SetterDynamic>(new Action<FVector2D>(this.OnPosTweenUpdate));
		}

		// Token: 0x06042C6A RID: 273514 RVA: 0x011231A0 File Offset: 0x011213A0
		protected override void OnBeforeShow()
		{
			IDropCatchGameplayFloatEffViewParams dropCatchGameplayFloatEffViewParams = this.OpenParam as IDropCatchGameplayFloatEffViewParams;
			this.InitPos(dropCatchGameplayFloatEffViewParams.Pos);
			if (!StringUtils.IsEmpty(dropCatchGameplayFloatEffViewParams.Icon))
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				base.TrySetSpriteByPath(dropCatchGameplayFloatEffViewParams.Icon, base.GetSprite(0), true, null, null);
			}
			else
			{
				UUIItem item2 = base.GetItem(2);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
			}
			if (dropCatchGameplayFloatEffViewParams.Score != null)
			{
				if (dropCatchGameplayFloatEffViewParams.IsOrangeScore)
				{
					UUIItem item3 = base.GetItem(3);
					if (item3 != null)
					{
						item3.SetUIActive(false);
					}
					UUIItem item4 = base.GetItem(4);
					if (item4 != null)
					{
						item4.SetUIActive(true);
					}
					UUIArtText artText = base.GetArtText(5);
					if (artText != null)
					{
						artText.SetText(dropCatchGameplayFloatEffViewParams.Score.Value.ToString());
					}
				}
				else
				{
					UUIItem item5 = base.GetItem(3);
					if (item5 != null)
					{
						item5.SetUIActive(true);
					}
					UUIItem item6 = base.GetItem(4);
					if (item6 != null)
					{
						item6.SetUIActive(false);
					}
					UUIArtText artText2 = base.GetArtText(1);
					if (artText2 != null)
					{
						artText2.SetText(dropCatchGameplayFloatEffViewParams.Score.Value.ToString());
					}
				}
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_goldcatch_efx_buff_time");
				return;
			}
			UUIItem item7 = base.GetItem(3);
			if (item7 != null)
			{
				item7.SetUIActive(false);
			}
			UUIItem item8 = base.GetItem(4);
			if (item8 == null)
			{
				return;
			}
			item8.SetUIActive(false);
		}

		// Token: 0x06042C6B RID: 273515 RVA: 0x011232FE File Offset: 0x011214FE
		private void OnPosTweenUpdate(FVector2D targetPos)
		{
			base.GetRootItem().SetAnchorOffset(targetPos);
		}

		// Token: 0x06042C6C RID: 273516 RVA: 0x0112330C File Offset: 0x0112150C
		protected void InitPos(Vector2D pos)
		{
			this.StartPos.Set(pos.X, pos.Y);
			this.EndPos.Set(pos.X, pos.Y + 100.0);
			base.GetRootItem().SetAnchorOffset(pos.ToUeVector2D(false));
		}

		// Token: 0x06042C6D RID: 273517 RVA: 0x01123363 File Offset: 0x01121563
		protected override void OnAfterShow()
		{
			this.PlayPosTween(this.StartPos, this.EndPos, DropCatchGameplayFloatEffView.TWEENTIME, LTweenEase.OutCubic);
			this.PlayAlphaTween();
		}

		// Token: 0x06042C6E RID: 273518 RVA: 0x01123384 File Offset: 0x01121584
		private void PlayPosTween(Vector2D startPos, Vector2D endPos, float tweenTime, LTweenEase tweenEase)
		{
			this.KillPosTweener();
			this.PosTweener = ULTweenBPLibrary.Vector2To(GlobalData.World, this.PosDelegate, startPos.ToUeVector2D(false), endPos.ToUeVector2D(false), tweenTime, 0f, tweenEase);
			this.PosTweener.OnCompleteCallBack.Bind(delegate()
			{
				Action<DropCatchGameplayPoolPanelBase> onRecycle = this.OnRecycle;
				if (onRecycle == null)
				{
					return;
				}
				onRecycle(this);
			});
		}

		// Token: 0x06042C6F RID: 273519 RVA: 0x011233DF File Offset: 0x011215DF
		private void PlayAlphaTween()
		{
			base.GetRootItem().PlayUIItemAlphaTween(1f, 0f, DropCatchGameplayFloatEffView.TWEENTIME);
		}

		// Token: 0x06042C70 RID: 273520 RVA: 0x011233FB File Offset: 0x011215FB
		private void KillPosTweener()
		{
			if (this.PosTweener != null)
			{
				this.PosTweener.Kill(false);
				this.PosTweener = null;
			}
		}

		// Token: 0x06042C71 RID: 273521 RVA: 0x01123418 File Offset: 0x01121618
		protected override void OnBeforeDestroy()
		{
			this.KillPosTweener();
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FVector2D>(this.OnPosTweenUpdate));
		}

		// Token: 0x04025345 RID: 152389
		private static readonly float TWEENTIME = 1.2f;

		// Token: 0x04025346 RID: 152390
		[Nullable(2)]
		private ULTweener PosTweener;

		// Token: 0x04025347 RID: 152391
		[Nullable(2)]
		private FLTweenVector2SetterDynamic PosDelegate;

		// Token: 0x04025348 RID: 152392
		private readonly Vector2D StartPos = Vector2D.Create();

		// Token: 0x04025349 RID: 152393
		private readonly Vector2D EndPos = Vector2D.Create();
	}
}
