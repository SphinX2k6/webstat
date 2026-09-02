using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C64 RID: 7268
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchPopupRewardItem : UiPanelBase
{
	// Token: 0x0600D41A RID: 54298 RVA: 0x00389148 File Offset: 0x00387348
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D41B RID: 54299 RVA: 0x003891D4 File Offset: 0x003873D4
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchPopupRewardItem.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchPopupRewardItem.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D41C RID: 54300 RVA: 0x00389217 File Offset: 0x00387417
	public void InitCurve(UCurveFloat lerpCurve)
	{
		this.LerpCurve = lerpCurve;
	}

	// Token: 0x0600D41D RID: 54301 RVA: 0x00389220 File Offset: 0x00387420
	public void Tick(float delta)
	{
		if (this.IsPlayingPopup)
		{
			this.StartTime += delta;
			float floatValue = this.LerpCurve.GetFloatValue(this.StartTime / this.Duration);
			Vector.Lerp(this.StartPoint, this.EndPoint, (double)floatValue, this.TempVector);
			UUIItem rootItem = base.GetRootItem();
			FVector fvector = this.TempVector.ToUeVectorOld();
			rootItem.SetUIWorldLocation(fvector);
			if (this.StartTime >= this.Duration + this.StayTime || ModelBase<FloroRanchGamePlayModel>.Instance.IsSkip)
			{
				UUIItem rootItem2 = base.GetRootItem();
				fvector = this.EndPoint.ToUeVectorOld();
				rootItem2.SetUIWorldLocation(fvector);
				this.ClearPopupCurve();
				Action popUpFinishCallback = this.PopUpFinishCallback;
				if (popUpFinishCallback == null)
				{
					return;
				}
				popUpFinishCallback();
			}
			return;
		}
		if (this.IsPlayingBezier)
		{
			float num = this.StartTime / this.Duration;
			num *= num;
			Vector pos = this.BezierCurve.GetPos((double)((num > 1f) ? 1f : num));
			UUIItem rootItem3 = base.GetRootItem();
			FVector fvector = pos.ToUeVectorOld();
			rootItem3.SetUIWorldLocation(fvector);
			this.StartTime += delta;
			if (this.StartTime >= this.Duration || ModelBase<FloroRanchGamePlayModel>.Instance.IsSkip)
			{
				UUIItem rootItem4 = base.GetRootItem();
				fvector = this.EndPoint.ToUeVectorOld();
				rootItem4.SetUIWorldLocation(fvector);
				Action bezierFinishCallback = this.BezierFinishCallback;
				if (bezierFinishCallback != null)
				{
					bezierFinishCallback();
				}
				this.ClearBezierCurve();
			}
		}
	}

	// Token: 0x0600D41E RID: 54302 RVA: 0x00389388 File Offset: 0x00387588
	public void PopupReward(Vector pointA, Vector pointB, [Nullable(2)] Action finishCallback = null)
	{
		if (ModelBase<FloroRanchGamePlayModel>.Instance.IsSkip)
		{
			if (finishCallback != null)
			{
				finishCallback();
			}
			return;
		}
		this.StartPoint = pointA;
		this.EndPoint = pointB;
		this.StartTime = 0f;
		this.Duration = 500f;
		this.StayTime = ModelBase<FloroRanchGamePlayModel>.Instance.GetPopupRewardStayTime();
		base.GetArtText(2).SetUIActive(true);
		this.IsPlayingPopup = true;
		UUIItem rootItem = base.GetRootItem();
		FVector fvector = pointA.ToUeVectorOld();
		rootItem.SetUIWorldLocation(fvector);
		this.PopUpFinishCallback = finishCallback;
	}

	// Token: 0x0600D41F RID: 54303 RVA: 0x00389410 File Offset: 0x00387610
	public void PlayBezierCurve(Vector pointA, Vector pointB, Action finishCallback)
	{
		if (ModelBase<FloroRanchGamePlayModel>.Instance.IsSkip)
		{
			if (finishCallback != null)
			{
				finishCallback();
			}
			return;
		}
		this.StartPoint = pointA;
		this.EndPoint = pointB;
		this.StartTime = 0f;
		this.Duration = ModelBase<FloroRanchGamePlayModel>.Instance.GetBezierCurveTime();
		base.GetArtText(2).SetUIActive(false);
		Vector upVetcor = (this.EndPoint.X > this.StartPoint.X) ? FloroRanchDefine.FloroRanchRewardRightDirection : FloroRanchDefine.FloroRanchRewardLeftDirection;
		this.BezierCurve.InitByFactor(this.StartPoint, this.EndPoint, upVetcor, 0.5, 0.5);
		this.IsPlayingBezier = true;
		this.BezierFinishCallback = finishCallback;
	}

	// Token: 0x0600D420 RID: 54304 RVA: 0x003894C8 File Offset: 0x003876C8
	public void Refresh(long count, string icon)
	{
		UUIArtText artText = base.GetArtText(2);
		artText.SetUIActive(true);
		artText.SetText(count.ToString());
		if (count >= 1000L)
		{
			artText.SetArtTextData(this.RedArtTextData);
		}
		else if (count >= 100L)
		{
			artText.SetArtTextData(this.YellowArtTextData);
		}
		else
		{
			artText.SetArtTextData(this.NormalArtTextData);
		}
		base.GetTexture(0).SetUIActive(false);
		base.SetTextureByPath(icon, base.GetTexture(1), null, null);
	}

	// Token: 0x0600D421 RID: 54305 RVA: 0x00389550 File Offset: 0x00387750
	public void PlayShowRewardAnim()
	{
		if (this.LevelSequencePlayer == null)
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}
		base.GetRootItem().SetUIActive(true);
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600D422 RID: 54306 RVA: 0x003895A0 File Offset: 0x003877A0
	public UniTask PlayHideRewardAnim()
	{
		FloroRanchPopupRewardItem.<PlayHideRewardAnim>d__25 <PlayHideRewardAnim>d__;
		<PlayHideRewardAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideRewardAnim>d__.<>4__this = this;
		<PlayHideRewardAnim>d__.<>1__state = -1;
		<PlayHideRewardAnim>d__.<>t__builder.Start<FloroRanchPopupRewardItem.<PlayHideRewardAnim>d__25>(ref <PlayHideRewardAnim>d__);
		return <PlayHideRewardAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D423 RID: 54307 RVA: 0x003895E4 File Offset: 0x003877E4
	public UniTask PlayCloseRewardAnim()
	{
		FloroRanchPopupRewardItem.<PlayCloseRewardAnim>d__26 <PlayCloseRewardAnim>d__;
		<PlayCloseRewardAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseRewardAnim>d__.<>4__this = this;
		<PlayCloseRewardAnim>d__.<>1__state = -1;
		<PlayCloseRewardAnim>d__.<>t__builder.Start<FloroRanchPopupRewardItem.<PlayCloseRewardAnim>d__26>(ref <PlayCloseRewardAnim>d__);
		return <PlayCloseRewardAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D424 RID: 54308 RVA: 0x00389628 File Offset: 0x00387828
	public void FollowPosition(Vector position)
	{
		UUIItem rootItem = base.GetRootItem();
		FVector fvector = position.ToUeVectorOld();
		rootItem.SetUIWorldLocation(fvector);
	}

	// Token: 0x0600D425 RID: 54309 RVA: 0x00389649 File Offset: 0x00387849
	protected override void OnBeforeDestroy()
	{
		this.ClearBezierCurve();
		this.ClearPopupCurve();
	}

	// Token: 0x0600D426 RID: 54310 RVA: 0x00389657 File Offset: 0x00387857
	private void ClearBezierCurve()
	{
		this.StartTime = 0f;
		this.Duration = 0f;
		this.BezierFinishCallback = null;
		this.IsPlayingBezier = false;
	}

	// Token: 0x0600D427 RID: 54311 RVA: 0x0038967D File Offset: 0x0038787D
	private void ClearPopupCurve()
	{
		this.StartTime = 0f;
		this.Duration = 0f;
		this.IsPlayingPopup = false;
	}

	// Token: 0x040064E4 RID: 25828
	public bool IsPlayingBezier;

	// Token: 0x040064E5 RID: 25829
	private bool IsPlayingPopup;

	// Token: 0x040064E6 RID: 25830
	private UCurveFloat LerpCurve;

	// Token: 0x040064E7 RID: 25831
	private Vector StartPoint = Vector.Create();

	// Token: 0x040064E8 RID: 25832
	private Vector EndPoint = Vector.Create();

	// Token: 0x040064E9 RID: 25833
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x040064EA RID: 25834
	private readonly BeizerQuadraticCurve BezierCurve = new BeizerQuadraticCurve();

	// Token: 0x040064EB RID: 25835
	private float StartTime;

	// Token: 0x040064EC RID: 25836
	private float Duration;

	// Token: 0x040064ED RID: 25837
	private float StayTime;

	// Token: 0x040064EE RID: 25838
	[Nullable(2)]
	private Action BezierFinishCallback;

	// Token: 0x040064EF RID: 25839
	[Nullable(2)]
	private Action PopUpFinishCallback;

	// Token: 0x040064F0 RID: 25840
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040064F1 RID: 25841
	[Nullable(2)]
	private ULGUIArtTextData NormalArtTextData;

	// Token: 0x040064F2 RID: 25842
	[Nullable(2)]
	private ULGUIArtTextData YellowArtTextData;

	// Token: 0x040064F3 RID: 25843
	[Nullable(2)]
	private ULGUIArtTextData RedArtTextData;

	// Token: 0x02007F7F RID: 32639
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B689 RID: 177801
		public const int MapIcon = 0;

		// Token: 0x0402B68A RID: 177802
		public const int Icon = 1;

		// Token: 0x0402B68B RID: 177803
		public const int Count = 2;
	}
}
