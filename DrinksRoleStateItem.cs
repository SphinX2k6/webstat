using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001029 RID: 4137
public class DrinksRoleStateItem : UiPanelBase
{
	// Token: 0x06006B91 RID: 27537 RVA: 0x001C2CC0 File Offset: 0x001C0EC0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
	}

	// Token: 0x06006B92 RID: 27538 RVA: 0x001C2DCC File Offset: 0x001C0FCC
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksRoleStateItem.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksRoleStateItem.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006B93 RID: 27539 RVA: 0x001C2E10 File Offset: 0x001C1010
	protected override void OnStart()
	{
		this.LevelSequence = new LevelSequencePlayer(base.GetItem(4));
		this.Layout = new GenericLayout<DrinksRoleRequireItem, IDrinksRequireInfo>(base.GetVerticalLayout(2), new Func<DrinksRoleRequireItem>(this.CreateRequestItem), null, false, true);
		UUISprite sprite = base.GetSprite(6);
		if (sprite != null)
		{
			sprite.SetFillAmount(0f);
		}
		UUISprite sprite2 = base.GetSprite(7);
		if (sprite2 != null)
		{
			sprite2.SetFillAmount(0f);
		}
		int roleId = ModelBase<DrinksModel>.Instance.GetRoleId();
		base.SetRoleIcon("", base.GetTexture(0), roleId, null, null);
		this.MaxScore = (float)ModelBase<DrinksModel>.Instance.GetLikenessMax();
		this.InitCurState();
		this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.UpdateProgress));
	}

	// Token: 0x06006B94 RID: 27540 RVA: 0x001C2ED4 File Offset: 0x001C10D4
	protected override void OnBeforeDestroy()
	{
		if (this.Delegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.UpdateProgress));
			this.Delegate = null;
		}
	}

	// Token: 0x06006B95 RID: 27541 RVA: 0x001C2EF8 File Offset: 0x001C10F8
	public void RefreshCurState()
	{
		ValueTuple<int, List<IDrinksRequireInfo>> roleState = ModelBase<DrinksModel>.Instance.GetRoleState();
		int item = roleState.Item1;
		List<IDrinksRequireInfo> item2 = roleState.Item2;
		GenericLayout<DrinksRoleRequireItem, IDrinksRequireInfo> layout = this.Layout;
		if (layout != null)
		{
			layout.RefreshByData(item2, null, false);
		}
		if ((float)item == this.EndLikeness)
		{
			return;
		}
		this.EndLikeness = (float)item;
		if (this.Tweener != null)
		{
			this.Tweener.Kill(false);
			this.Tweener = null;
		}
		this.Tweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.Delegate, this.CurLikeness, (float)item, 0.5f, 0f, LTweenEase.OutCubic);
		if (this.Tweener != null)
		{
			this.Tweener.OnCompleteCallBack.Bind(new Action(this.OnTweenerEnd));
			this.Tweener.SetCurveFloat(this.Curve);
		}
	}

	// Token: 0x06006B96 RID: 27542 RVA: 0x001C2FC0 File Offset: 0x001C11C0
	protected void InitCurState()
	{
		List<IDrinksRequireInfo> item = ModelBase<DrinksModel>.Instance.GetRoleState().Item2;
		GenericLayout<DrinksRoleRequireItem, IDrinksRequireInfo> layout = this.Layout;
		if (layout != null)
		{
			layout.RefreshByData(item, null, false);
		}
		this.EndLikeness = 0f;
		this.RefreshLikeTxt(0f, true);
		UUISprite sprite = base.GetSprite(6);
		if (sprite != null)
		{
			sprite.SetFillAmount(0f);
		}
		UUISprite sprite2 = base.GetSprite(7);
		if (sprite2 == null)
		{
			return;
		}
		sprite2.SetFillAmount(0f);
	}

	// Token: 0x06006B97 RID: 27543 RVA: 0x001C3038 File Offset: 0x001C1238
	protected void RefreshLikeTxt(float value, bool isInit)
	{
		int num;
		if (value < 0f)
		{
			num = 0;
		}
		else if (value == 0f)
		{
			num = 1;
		}
		else
		{
			num = ((value >= this.MaxScore) ? 3 : 2);
		}
		if (num == this.CurLikenessState && !isInit)
		{
			return;
		}
		this.CurLikenessState = num;
		float alpha = (value < 0f) ? 1f : 0.5f;
		UUITexture texture = base.GetTexture(8);
		if (texture != null)
		{
			texture.SetAlpha(alpha);
		}
		float alpha2 = (value > 0f) ? 1f : 0.5f;
		UUITexture texture2 = base.GetTexture(9);
		if (texture2 != null)
		{
			texture2.SetAlpha(alpha2);
		}
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(value >= this.MaxScore);
		}
		string resourceId = (value >= this.MaxScore) ? "T_TiaoJiuIconLikeLevel03" : "T_TiaoJiuIconLikeLevel02";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(9), null, null);
		string textStringId;
		if (value < 0f)
		{
			textStringId = "DRINKS_Drinklist_likeStr_Dislike";
		}
		else if (value == 0f)
		{
			textStringId = "DRINKS_Drinklist_likeStr_Justlike";
		}
		else if (value < this.MaxScore)
		{
			textStringId = "DRINKS_Drinklist_likeStr_like";
		}
		else
		{
			textStringId = "DRINKS_Drinklist_likeStr_Perferlike";
		}
		if (value >= this.MaxScore)
		{
			LevelSequencePlayer levelSequence = this.LevelSequence;
			if (levelSequence != null)
			{
				levelSequence.PlayLevelSequenceByName("Max", false, null, false);
			}
		}
		else
		{
			LevelSequencePlayer levelSequence2 = this.LevelSequence;
			if (levelSequence2 != null && levelSequence2.IsPlayingSequence("Max"))
			{
				LevelSequencePlayer levelSequence3 = this.LevelSequence;
				if (levelSequence3 != null)
				{
					levelSequence3.StopPlayingSequence(false, true);
				}
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textStringId, Array.Empty<object>());
	}

	// Token: 0x06006B98 RID: 27544 RVA: 0x001C31D8 File Offset: 0x001C13D8
	[NullableContext(1)]
	private DrinksRoleRequireItem CreateRequestItem()
	{
		return new DrinksRoleRequireItem();
	}

	// Token: 0x06006B99 RID: 27545 RVA: 0x001C31E0 File Offset: 0x001C13E0
	private void UpdateProgress(float value)
	{
		this.RefreshLikeTxt(value, false);
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(value >= this.MaxScore);
		}
		if (value >= 0f)
		{
			UUISprite sprite = base.GetSprite(6);
			if (sprite != null)
			{
				sprite.SetFillAmount(0f);
			}
			UUISprite sprite2 = base.GetSprite(7);
			if (sprite2 != null)
			{
				sprite2.SetFillAmount(value / this.MaxScore);
			}
		}
		else
		{
			UUISprite sprite3 = base.GetSprite(6);
			if (sprite3 != null)
			{
				sprite3.SetFillAmount(-value / this.MaxScore);
			}
			UUISprite sprite4 = base.GetSprite(7);
			if (sprite4 != null)
			{
				sprite4.SetFillAmount(0f);
			}
		}
		this.CurLikeness = value;
	}

	// Token: 0x06006B9A RID: 27546 RVA: 0x001C3288 File Offset: 0x001C1488
	private void OnTweenerEnd()
	{
		this.CurLikeness = this.EndLikeness;
		if (this.Tweener != null)
		{
			this.Tweener = null;
		}
	}

	// Token: 0x04003329 RID: 13097
	[Nullable(2)]
	protected ULTweener Tweener;

	// Token: 0x0400332A RID: 13098
	[Nullable(2)]
	protected FLTweenFloatSetterDynamic Delegate;

	// Token: 0x0400332B RID: 13099
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<DrinksRoleRequireItem, IDrinksRequireInfo> Layout;

	// Token: 0x0400332C RID: 13100
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequence;

	// Token: 0x0400332D RID: 13101
	protected float CurLikeness;

	// Token: 0x0400332E RID: 13102
	protected float EndLikeness;

	// Token: 0x0400332F RID: 13103
	protected int CurLikenessState = 1;

	// Token: 0x04003330 RID: 13104
	protected float MaxScore;

	// Token: 0x04003331 RID: 13105
	[Nullable(1)]
	protected UCurveFloat Curve;

	// Token: 0x02007408 RID: 29704
	private static class ECurFavorState
	{
		// Token: 0x04028212 RID: 164370
		public const int Dislike = 0;

		// Token: 0x04028213 RID: 164371
		public const int Zero = 1;

		// Token: 0x04028214 RID: 164372
		public const int Like = 2;

		// Token: 0x04028215 RID: 164373
		public const int VeryLike = 3;
	}

	// Token: 0x02007409 RID: 29705
	private static class EDefine
	{
		// Token: 0x04028216 RID: 164374
		public const int TexHeadIcon = 0;

		// Token: 0x04028217 RID: 164375
		public const int TxtTitle = 1;

		// Token: 0x04028218 RID: 164376
		public const int Content = 2;

		// Token: 0x04028219 RID: 164377
		public const int RequestItem = 3;

		// Token: 0x0402821A RID: 164378
		public const int PanelLikeness = 4;

		// Token: 0x0402821B RID: 164379
		public const int TxtLikeState = 5;

		// Token: 0x0402821C RID: 164380
		public const int SpriteNotLike = 6;

		// Token: 0x0402821D RID: 164381
		public const int SpriteLike = 7;

		// Token: 0x0402821E RID: 164382
		public const int TexNotLike = 8;

		// Token: 0x0402821F RID: 164383
		public const int TexLike = 9;

		// Token: 0x04028220 RID: 164384
		public const int PanelFxLike = 10;
	}
}
