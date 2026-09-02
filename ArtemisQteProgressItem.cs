using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011BE RID: 4542
[NullableContext(1)]
[Nullable(0)]
public class ArtemisQteProgressItem : UiPanelBase
{
	// Token: 0x06007779 RID: 30585 RVA: 0x001F3FC4 File Offset: 0x001F21C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
	}

	// Token: 0x0600777A RID: 30586 RVA: 0x001F40A2 File Offset: 0x001F22A2
	protected override void OnStart()
	{
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x0600777B RID: 30587 RVA: 0x001F40B1 File Offset: 0x001F22B1
	protected override void OnBeforeDestroy()
	{
		this.BgItemList.Clear();
		this.QteAreaTextures.Clear();
		this.PerfectAreaTextures.Clear();
		this.CachedTexture.Clear();
	}

	// Token: 0x0600777C RID: 30588 RVA: 0x001F40E0 File Offset: 0x001F22E0
	public void Init(int gamePlayId, ArtemisQteGameInfo gameInfo)
	{
		this.GameInfo = gameInfo;
		this.RingInfo = this.GameInfo.GetRingInfo();
		this.GamePlayId = gamePlayId;
		ArtemisQte value = ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisQteConfigById(this.GamePlayId).Value;
		this.AnimTime = Math.Max(value.HitColdTime, 100);
		float num = value.HiddenInterval(0);
		float num2 = value.HiddenInterval(1);
		float num3 = 2f * num + num2;
		if (num3 > 0f)
		{
			this.PeriodAlphaTotalTime = num3;
		}
	}

	// Token: 0x0600777D RID: 30589 RVA: 0x001F4168 File Offset: 0x001F2368
	public void InitRing()
	{
		this.RingInfo.ClearValidAreas();
		this.SpawnBgArea().Forget();
		this.InitAllQteAreas();
		float cursorSpeed = this.GameInfo.CursorSpeed;
		float ringSpeed = this.GameInfo.RingSpeed;
		if (cursorSpeed > 0f && ringSpeed > 0f)
		{
			return;
		}
		this.RotateMode = ((cursorSpeed > 0f) ? EArtemisRotateMode.Arrow : EArtemisRotateMode.Ring);
	}

	// Token: 0x0600777E RID: 30590 RVA: 0x001F41CC File Offset: 0x001F23CC
	public void OnTick(float delta)
	{
		float currentProgress = this.GetCurrentProgress();
		this.RefreshAnimProgress(currentProgress, delta);
		this.RefreshProgress(currentProgress);
		this.RefreshArrow(delta);
	}

	// Token: 0x0600777F RID: 30591 RVA: 0x001F41F8 File Offset: 0x001F23F8
	private void RefreshArrow(float delta)
	{
		if (this.GameInfo.IsGamePause())
		{
			return;
		}
		float cursorSpeed = this.GameInfo.CursorSpeed;
		float ringSpeed = this.GameInfo.RingSpeed;
		float cursorSpeed2 = (this.RotateMode == EArtemisRotateMode.Arrow) ? cursorSpeed : ringSpeed;
		ArtemisQteRingInfo ringInfo = this.RingInfo;
		int direction = (ringInfo != null && ringInfo.ArrowDirection == EArrowDirection.Clockwise) ? -1 : 1;
		float deltaSecond = delta / 1000f;
		this.CurrentRotator.Yaw = this.GetRotatorYaw(direction, cursorSpeed2, deltaSecond);
		UUIItem item = base.GetItem(7);
		EArtemisRotateMode rotateMode = this.RotateMode;
		if (rotateMode != EArtemisRotateMode.Arrow)
		{
			if (rotateMode == EArtemisRotateMode.Ring)
			{
				foreach (ArtemisQteRingBgSingleItem artemisQteRingBgSingleItem in this.BgItemList)
				{
					UUIItem uuiitem = (artemisQteRingBgSingleItem != null) ? artemisQteRingBgSingleItem.GetRootItem() : null;
					if (uuiitem != null && uuiitem.IsUIActiveSelf())
					{
						UUIItem uuiitem2 = uuiitem;
						FRotator frotator = this.CurrentRotator.ToUeRotator();
						uuiitem2.SetUIRelativeRotation(frotator);
					}
				}
				foreach (int continuousIndex in this.RingInfo.GetQteAreas().Keys)
				{
					UUIItem qteAreaTexture = this.GetQteAreaTexture(continuousIndex);
					FRotator frotator = this.CurrentRotator.ToUeRotator();
					qteAreaTexture.SetUIRelativeRotation(frotator);
				}
				foreach (int continuousIndex2 in this.RingInfo.GetPerfectAreas().Keys)
				{
					UUIItem perfectAreaTexture = this.GetPerfectAreaTexture(continuousIndex2);
					FRotator frotator = this.CurrentRotator.ToUeRotator();
					perfectAreaTexture.SetUIRelativeRotation(frotator);
				}
				this.RingInfo.CurrentArrowStayCellIndex = 36 - this.GetCurrentArrowStayCellIndex() + 1;
			}
		}
		else
		{
			if (item != null)
			{
				UUIItem uuiitem3 = item;
				FRotator frotator = this.CurrentRotator.ToUeRotator();
				uuiitem3.SetUIRelativeRotation(frotator);
			}
			this.RingInfo.CurrentArrowStayCellIndex = this.GetCurrentArrowStayCellIndex();
		}
		if (this.PeriodAlphaTotalTime > 0f)
		{
			float alphaInAlphaPeriod = this.GetAlphaInAlphaPeriod(this.PeriodAlphaCurrentTime);
			foreach (int continuousIndex3 in this.RingInfo.GetQteAreas().Keys)
			{
				this.GetQteAreaTexture(continuousIndex3).SetAlpha(alphaInAlphaPeriod);
			}
			foreach (int continuousIndex4 in this.RingInfo.GetPerfectAreas().Keys)
			{
				this.GetPerfectAreaTexture(continuousIndex4).SetAlpha(alphaInAlphaPeriod);
			}
			this.PeriodAlphaCurrentTime += delta;
			if (this.PeriodAlphaCurrentTime >= this.PeriodAlphaTotalTime)
			{
				this.PeriodAlphaCurrentTime = 0f;
			}
		}
	}

	// Token: 0x06007780 RID: 30592 RVA: 0x001F4500 File Offset: 0x001F2700
	private float GetAlphaInAlphaPeriod(float currentTime)
	{
		ArtemisQte value = ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisQteConfigById(this.GamePlayId).Value;
		float num = value.HiddenInterval(0);
		float num2 = value.HiddenInterval(1);
		float num3 = value.HiddenInterval(2);
		float num4 = (num2 - num3) / 2f;
		if (currentTime < num)
		{
			return 1f;
		}
		if (currentTime < num + num4)
		{
			return 1f - (currentTime - num) / num4;
		}
		if (currentTime < num + num4 + num3)
		{
			return 0f;
		}
		if (currentTime < num + num2)
		{
			return (currentTime - num - num4 - num3) / num4;
		}
		return 1f;
	}

	// Token: 0x06007781 RID: 30593 RVA: 0x001F4594 File Offset: 0x001F2794
	private int GetCurrentArrowStayCellIndex()
	{
		return (int)(Math.Floor((double)(Math.Abs(this.CurrentRotator.Yaw) % 360f / 10f)) + 1.0);
	}

	// Token: 0x06007782 RID: 30594 RVA: 0x001F45C4 File Offset: 0x001F27C4
	private float GetRotatorYaw(int direction, float cursorSpeed, float deltaSecond)
	{
		float num = this.CurrentRotator.Yaw;
		ArtemisQteRingInfo ringInfo = this.RingInfo;
		if (ringInfo != null && ringInfo.IsWholeRing)
		{
			num += (float)direction * (cursorSpeed * deltaSecond);
		}
		else
		{
			num += (float)direction * (cursorSpeed * deltaSecond);
			if (num < this.ArrowActiveEndYawAngle)
			{
				num = this.ArrowActiveEndYawAngle + 1f;
				this.RingInfo.OnArrowDirectionReverse();
			}
			if (num > this.ArrowActiveStartYawAngle)
			{
				num = this.ArrowActiveStartYawAngle;
				this.RingInfo.OnArrowDirectionReverse();
			}
		}
		if (num > 0f)
		{
			num -= 360f;
		}
		return num % (float)ArtemisQteProgressItem.YAW_MAX_ANGLE;
	}

	// Token: 0x06007783 RID: 30595 RVA: 0x001F465C File Offset: 0x001F285C
	[NullableContext(2)]
	public void OnAreaClick(EArtemisAreaType areaType, ContinuousRingArea area)
	{
		switch (areaType)
		{
		case EArtemisAreaType.BlankArea:
			this.AllAreaPlayingSequenceName = null;
			this.PlayAnim("Miss");
			return;
		case EArtemisAreaType.QteArea:
			this.PeriodAlphaCurrentTime = 0f;
			this.AllAreaPlayingSequenceName = null;
			this.OncePlayingSequenceName = "Success";
			this.StopTargetPlayingSequence("Perfect");
			this.StopTargetPlayingSequence("Perfect_Light");
			if (area != null)
			{
				this.AnyTargetPlayAnim(areaType, "Success", area.ContinuousIndex, true);
				return;
			}
			break;
		case EArtemisAreaType.PerfectArea:
			this.PeriodAlphaCurrentTime = 0f;
			this.AllAreaPlayingSequenceName = "Perfect";
			this.OncePlayingSequenceName = "Perfect_Light";
			this.PlayAnim("Perfect");
			if (area != null)
			{
				this.AnyTargetPlayAnim(areaType, "Perfect_Light", area.ContinuousIndex, false);
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06007784 RID: 30596 RVA: 0x001F471C File Offset: 0x001F291C
	public void PlayAnim(string sequenceName)
	{
		foreach (ArtemisQteRingSingleItem artemisQteRingSingleItem in this.QteAreaTextures.Values)
		{
			if (artemisQteRingSingleItem != null)
			{
				artemisQteRingSingleItem.PlayAnim(sequenceName);
			}
		}
		foreach (ArtemisQteRingSingleItem artemisQteRingSingleItem2 in this.PerfectAreaTextures.Values)
		{
			if (artemisQteRingSingleItem2 != null)
			{
				artemisQteRingSingleItem2.PlayAnim(sequenceName);
			}
		}
	}

	// Token: 0x06007785 RID: 30597 RVA: 0x001F47C4 File Offset: 0x001F29C4
	public void StopTargetPlayingSequence(string sequenceName)
	{
		foreach (ArtemisQteRingSingleItem artemisQteRingSingleItem in this.QteAreaTextures.Values)
		{
			if (artemisQteRingSingleItem != null)
			{
				artemisQteRingSingleItem.StopPlayingSequence(sequenceName);
			}
		}
		foreach (ArtemisQteRingSingleItem artemisQteRingSingleItem2 in this.PerfectAreaTextures.Values)
		{
			if (artemisQteRingSingleItem2 != null)
			{
				artemisQteRingSingleItem2.StopPlayingSequence(sequenceName);
			}
		}
	}

	// Token: 0x06007786 RID: 30598 RVA: 0x001F486C File Offset: 0x001F2A6C
	public void AnyTargetPlayAnim(EArtemisAreaType areaType, string sequenceName, int continuousIndex, bool needStop)
	{
		if (areaType == EArtemisAreaType.PerfectArea)
		{
			using (Dictionary<int, ArtemisQteRingSingleItem>.Enumerator enumerator = this.PerfectAreaTextures.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, ArtemisQteRingSingleItem> keyValuePair = enumerator.Current;
					if (this.PerfectAreaTextures.Count <= 1)
					{
						this.RingSingleItemPlayAnim(keyValuePair.Value, sequenceName, needStop);
						break;
					}
					if (keyValuePair.Key != continuousIndex)
					{
						this.RingSingleItemPlayAnim(keyValuePair.Value, sequenceName, needStop);
						break;
					}
				}
				return;
			}
		}
		foreach (KeyValuePair<int, ArtemisQteRingSingleItem> keyValuePair2 in this.QteAreaTextures)
		{
			if (this.QteAreaTextures.Count <= 1)
			{
				this.RingSingleItemPlayAnim(keyValuePair2.Value, sequenceName, needStop);
				break;
			}
			if (keyValuePair2.Key != continuousIndex)
			{
				this.RingSingleItemPlayAnim(keyValuePair2.Value, sequenceName, needStop);
				break;
			}
		}
	}

	// Token: 0x06007787 RID: 30599 RVA: 0x001F4978 File Offset: 0x001F2B78
	private void RingSingleItemPlayAnim(ArtemisQteRingSingleItem item, string sequenceName, bool needStop)
	{
		if (item != null)
		{
			if (needStop)
			{
				item.PlayAnim(sequenceName);
				return;
			}
			item.PlayLevelSequenceByName(sequenceName);
		}
	}

	// Token: 0x06007788 RID: 30600 RVA: 0x001F4990 File Offset: 0x001F2B90
	private void PlayCacheAnim(EArtemisAreaType areaType, int continuousIndex)
	{
		ArtemisQteRingSingleItem artemisQteRingSingleItem2;
		ArtemisQteRingSingleItem artemisQteRingSingleItem3;
		ArtemisQteRingSingleItem artemisQteRingSingleItem = (areaType == EArtemisAreaType.PerfectArea) ? (this.PerfectAreaTextures.TryGetValue(continuousIndex, out artemisQteRingSingleItem2) ? artemisQteRingSingleItem2 : null) : (this.QteAreaTextures.TryGetValue(continuousIndex, out artemisQteRingSingleItem3) ? artemisQteRingSingleItem3 : null);
		if (artemisQteRingSingleItem != null)
		{
			if (this.AllAreaPlayingSequenceName != null)
			{
				artemisQteRingSingleItem.PlayAnim(this.AllAreaPlayingSequenceName);
			}
			if (this.OncePlayingSequenceName != null)
			{
				artemisQteRingSingleItem.PlayLevelSequenceByName(this.OncePlayingSequenceName);
				this.OncePlayingSequenceName = null;
			}
		}
	}

	// Token: 0x06007789 RID: 30601 RVA: 0x001F4A00 File Offset: 0x001F2C00
	private void RefreshProgress(float progress)
	{
		int value = (int)Math.Ceiling((double)(progress * 100f));
		UUIText text = base.GetText(5);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		this.CurrentFillAmountRotator.Yaw = Singleton<MathUtils>.Instance.Lerp(-53f, 0f, progress);
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		FRotator frotator = this.CurrentFillAmountRotator.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0600778A RID: 30602 RVA: 0x001F4A90 File Offset: 0x001F2C90
	private void RefreshAnimProgress(float currentProgress, float delta)
	{
		float alpha = currentProgress;
		if (this.InAnim)
		{
			this.CurrentAnimTime += (int)delta;
			if (0 < this.CurrentAnimTime && this.CurrentAnimTime <= this.AnimTime)
			{
				float alpha2 = (float)this.CurrentAnimTime / (float)this.AnimTime;
				alpha = Singleton<MathUtils>.Instance.Lerp(this.AnimStartProgress, currentProgress, alpha2);
			}
			else
			{
				this.InAnim = false;
				alpha = currentProgress;
			}
		}
		this.AnimRotator.Yaw = Singleton<MathUtils>.Instance.Lerp(-53f, 0f, alpha);
	}

	// Token: 0x0600778B RID: 30603 RVA: 0x001F4B20 File Offset: 0x001F2D20
	public void OnArrowStayAreaUpdate(int relativeValidAreaIndex)
	{
		List<RingArea> validAreas = this.GameInfo.GetRingInfo().GetValidAreas();
		if (relativeValidAreaIndex < 0 || relativeValidAreaIndex >= validAreas.Count)
		{
			return;
		}
		RingArea ringArea = validAreas[relativeValidAreaIndex];
		this.ArrowActiveStartYawAngle = (float)(-(float)Math.Max(ringArea.StartCellIndex - 1, 0) * 10);
		this.ArrowActiveEndYawAngle = (float)(-(float)ringArea.EndCellIndex * 10);
		if (this.ArrowActiveEndYawAngle >= this.ArrowActiveStartYawAngle)
		{
			this.ArrowActiveEndYawAngle -= 360f;
		}
		EArrowDirection arrowDirection = ringArea.ArrowDirection;
		if (arrowDirection != EArrowDirection.Clockwise)
		{
			if (arrowDirection == EArrowDirection.Anticlockwise)
			{
				this.CurrentRotator.Yaw = this.ArrowActiveEndYawAngle;
			}
		}
		else
		{
			this.CurrentRotator.Yaw = this.ArrowActiveStartYawAngle;
		}
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		FRotator frotator = this.CurrentRotator.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
	}

	// Token: 0x0600778C RID: 30604 RVA: 0x001F4BF4 File Offset: 0x001F2DF4
	private float GetCurrentProgress()
	{
		int currentScore = this.GameInfo.CurrentScore;
		int maxScore = ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisQteConfigById(this.GamePlayId).Value.MaxScore;
		return Singleton<MathUtils>.Instance.Clamp((float)currentScore / (float)maxScore, 0f, 1f);
	}

	// Token: 0x0600778D RID: 30605 RVA: 0x001F4C48 File Offset: 0x001F2E48
	public void StartAnimProgress()
	{
		this.AnimStartProgress = this.GetCurrentProgress();
		this.CurrentAnimTime = 0;
		this.InAnim = true;
	}

	// Token: 0x0600778E RID: 30606 RVA: 0x001F4C64 File Offset: 0x001F2E64
	public void EnterNextRound()
	{
		this.AnimStartProgress = 0f;
	}

	// Token: 0x0600778F RID: 30607 RVA: 0x001F4C74 File Offset: 0x001F2E74
	private int GetAreaRandomSize(int[] rangeConfig)
	{
		int result = 3;
		if (rangeConfig != null && rangeConfig.Length >= 2)
		{
			result = this.RandomRangeInt(rangeConfig[0], rangeConfig[1]);
		}
		return result;
	}

	// Token: 0x06007790 RID: 30608 RVA: 0x001F4C9A File Offset: 0x001F2E9A
	private int RandomRangeInt(int start, int end)
	{
		return Math.Min(end, (int)Math.Floor(Singleton<MathUtils>.Instance.GetRandomRange((double)start, (double)(end + 1))));
	}

	// Token: 0x06007791 RID: 30609 RVA: 0x001F4CB8 File Offset: 0x001F2EB8
	public void ResetArea(int continuousIndex, EArtemisAreaType areaType)
	{
		if (areaType != EArtemisAreaType.QteArea)
		{
			if (areaType != EArtemisAreaType.PerfectArea)
			{
				return;
			}
			this.RingInfo.RemovePerfectArea(continuousIndex);
			ArtemisQteRingSingleItem artemisQteRingSingleItem;
			if (this.PerfectAreaTextures.TryGetValue(continuousIndex, out artemisQteRingSingleItem))
			{
				artemisQteRingSingleItem.SetUiActive(false);
				this.CachedTexture.Add(artemisQteRingSingleItem);
				this.PerfectAreaTextures.Remove(continuousIndex);
			}
		}
		else
		{
			this.RingInfo.RemoveQteArea(continuousIndex);
			ArtemisQteRingSingleItem artemisQteRingSingleItem2;
			if (this.QteAreaTextures.TryGetValue(continuousIndex, out artemisQteRingSingleItem2))
			{
				artemisQteRingSingleItem2.SetUiActive(false);
				this.CachedTexture.Add(artemisQteRingSingleItem2);
				this.QteAreaTextures.Remove(continuousIndex);
				return;
			}
		}
	}

	// Token: 0x06007792 RID: 30610 RVA: 0x001F4D47 File Offset: 0x001F2F47
	public void ResetAreaInLink(int continuousIndex, EArtemisAreaType areaType)
	{
		if (areaType != EArtemisAreaType.QteArea)
		{
			if (areaType != EArtemisAreaType.PerfectArea)
			{
				return;
			}
			this.ResetArea(continuousIndex, EArtemisAreaType.PerfectArea);
			this.ResetArea(continuousIndex, EArtemisAreaType.QteArea);
		}
		else
		{
			this.ResetArea(continuousIndex, EArtemisAreaType.QteArea);
			if (this.PerfectAreaTextures.ContainsKey(continuousIndex))
			{
				this.ResetArea(continuousIndex, EArtemisAreaType.PerfectArea);
				return;
			}
		}
	}

	// Token: 0x06007793 RID: 30611 RVA: 0x001F4D84 File Offset: 0x001F2F84
	public void ResetAllArea()
	{
		foreach (int continuousIndex in new List<int>(this.QteAreaTextures.Keys))
		{
			this.ResetArea(continuousIndex, EArtemisAreaType.QteArea);
		}
		foreach (int continuousIndex2 in new List<int>(this.PerfectAreaTextures.Keys))
		{
			this.ResetArea(continuousIndex2, EArtemisAreaType.PerfectArea);
		}
	}

	// Token: 0x06007794 RID: 30612 RVA: 0x001F4E30 File Offset: 0x001F3030
	private UniTask GenerateAreaWithTexture(int continuousIndex, EArtemisAreaType areaType, int startIndex, int areaSize)
	{
		ArtemisQteProgressItem.<GenerateAreaWithTexture>d__54 <GenerateAreaWithTexture>d__;
		<GenerateAreaWithTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GenerateAreaWithTexture>d__.<>4__this = this;
		<GenerateAreaWithTexture>d__.continuousIndex = continuousIndex;
		<GenerateAreaWithTexture>d__.areaType = areaType;
		<GenerateAreaWithTexture>d__.startIndex = startIndex;
		<GenerateAreaWithTexture>d__.areaSize = areaSize;
		<GenerateAreaWithTexture>d__.<>1__state = -1;
		<GenerateAreaWithTexture>d__.<>t__builder.Start<ArtemisQteProgressItem.<GenerateAreaWithTexture>d__54>(ref <GenerateAreaWithTexture>d__);
		return <GenerateAreaWithTexture>d__.<>t__builder.Task;
	}

	// Token: 0x06007795 RID: 30613 RVA: 0x001F4E94 File Offset: 0x001F3094
	private UniTask GenerateQteArea(int continuousIndex, int startIndex, int areaSize)
	{
		ArtemisQteProgressItem.<GenerateQteArea>d__55 <GenerateQteArea>d__;
		<GenerateQteArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GenerateQteArea>d__.<>4__this = this;
		<GenerateQteArea>d__.continuousIndex = continuousIndex;
		<GenerateQteArea>d__.startIndex = startIndex;
		<GenerateQteArea>d__.areaSize = areaSize;
		<GenerateQteArea>d__.<>1__state = -1;
		<GenerateQteArea>d__.<>t__builder.Start<ArtemisQteProgressItem.<GenerateQteArea>d__55>(ref <GenerateQteArea>d__);
		return <GenerateQteArea>d__.<>t__builder.Task;
	}

	// Token: 0x06007796 RID: 30614 RVA: 0x001F4EF0 File Offset: 0x001F30F0
	public void SpawnAreaAtValidArea(int continuousIndex, RingArea validArea)
	{
		int startCellIndex = validArea.StartCellIndex;
		int endCellIndex = validArea.EndCellIndex;
		ArtemisQte value = ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisQteConfigById(this.GamePlayId).Value;
		int num = ArtemisQteDefine.CalculateCellSize(startCellIndex, endCellIndex);
		int[] randomAreaArray = value.GetRandomAreaArray();
		int areaRandomSize = this.GetAreaRandomSize(randomAreaArray ?? Array.Empty<int>());
		if (num <= areaRandomSize)
		{
			this.GenerateQteArea(continuousIndex, startCellIndex, num).Forget();
			return;
		}
		if (endCellIndex >= startCellIndex)
		{
			int startIndex = this.RandomRangeInt(startCellIndex, endCellIndex - areaRandomSize + 1);
			this.GenerateQteArea(continuousIndex, startIndex, areaRandomSize).Forget();
			return;
		}
		int num2 = startCellIndex + num - 1;
		int startIndex2 = this.RandomRangeInt(startCellIndex, num2 - areaRandomSize + 1) % 36;
		this.GenerateQteArea(continuousIndex, startIndex2, areaRandomSize).Forget();
	}

	// Token: 0x06007797 RID: 30615 RVA: 0x001F4FB0 File Offset: 0x001F31B0
	private void SpawnWholeRingAllArea()
	{
		ContinuousRingArea continuousRingArea;
		int num = this.RingInfo.GetQteAreas().TryGetValue(0, out continuousRingArea) ? continuousRingArea.StartCellIndex : 0;
		ArtemisQte value = ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisQteConfigById(this.GamePlayId).Value;
		this.ResetAllArea();
		float num2 = 36f / (float)value.MultiBoxGroup;
		if (num2 != (float)((int)num2))
		{
			return;
		}
		int multiBoxGroup = value.MultiBoxGroup;
		int num3 = this.RandomRangeInt(1, 36);
		if (multiBoxGroup == 1 && num != 0)
		{
			int[] randomAreaArray = value.GetRandomAreaArray();
			int areaRandomSize = this.GetAreaRandomSize(randomAreaArray ?? Array.Empty<int>());
			int startIndex = (num + 18) % 36;
			this.GenerateQteArea(0, startIndex, areaRandomSize).Forget();
			return;
		}
		for (int i = 0; i < multiBoxGroup; i++)
		{
			int[] randomAreaArray2 = value.GetRandomAreaArray();
			int areaRandomSize2 = this.GetAreaRandomSize(randomAreaArray2 ?? Array.Empty<int>());
			int startIndex2 = i * (int)num2 + num3 + 1;
			this.GenerateQteArea(i, startIndex2, areaRandomSize2).Forget();
		}
	}

	// Token: 0x06007798 RID: 30616 RVA: 0x001F50B4 File Offset: 0x001F32B4
	private void SpawnIncompleteRingAllArea()
	{
		this.ResetAllArea();
		ArtemisQteRingInfo ringInfo = this.RingInfo;
		List<RingArea> list = (ringInfo != null) ? ringInfo.GetValidAreas() : null;
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				this.SpawnAreaAtValidArea(i, list[i]);
			}
		}
	}

	// Token: 0x06007799 RID: 30617 RVA: 0x001F50FC File Offset: 0x001F32FC
	public void InitAllQteAreas()
	{
		ArtemisQteRingInfo ringInfo = this.RingInfo;
		if (ringInfo != null && ringInfo.IsWholeRing)
		{
			this.SpawnWholeRingAllArea();
			return;
		}
		this.SpawnIncompleteRingAllArea();
	}

	// Token: 0x0600779A RID: 30618 RVA: 0x001F5120 File Offset: 0x001F3320
	public void SpawnContinuousArea(int continuousIndex, EArtemisAreaType type = EArtemisAreaType.QteArea)
	{
		ArtemisQteRingInfo ringInfo = this.RingInfo;
		if (ringInfo != null && ringInfo.IsWholeRing)
		{
			switch (ConfigBase<ArtemisActivityConfig>.Instance.GetArtemisQteConfigById(this.GamePlayId).Value.RefreshType)
			{
			case 0:
				break;
			case 1:
				this.SpawnWholeRingAllArea();
				return;
			case 2:
				this.ResetAreaInLink(continuousIndex, type);
				if (this.RingInfo.GetQteAreas().Count == 0)
				{
					this.SpawnWholeRingAllArea();
					return;
				}
				break;
			default:
				return;
			}
		}
		else
		{
			List<RingArea> validAreas = this.RingInfo.GetValidAreas();
			this.ResetAreaInLink(continuousIndex, type);
			this.SpawnAreaAtValidArea(continuousIndex, validAreas[continuousIndex]);
		}
	}

	// Token: 0x0600779B RID: 30619 RVA: 0x001F51BF File Offset: 0x001F33BF
	public UUIItem GetQteAreaTexture(int continuousIndex)
	{
		return this.QteAreaTextures[continuousIndex].GetRootItem();
	}

	// Token: 0x0600779C RID: 30620 RVA: 0x001F51D2 File Offset: 0x001F33D2
	public UUIItem GetPerfectAreaTexture(int continuousIndex)
	{
		return this.PerfectAreaTextures[continuousIndex].GetRootItem();
	}

	// Token: 0x0600779D RID: 30621 RVA: 0x001F51E8 File Offset: 0x001F33E8
	public UniTask SpawnBgArea()
	{
		ArtemisQteProgressItem.<SpawnBgArea>d__63 <SpawnBgArea>d__;
		<SpawnBgArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SpawnBgArea>d__.<>4__this = this;
		<SpawnBgArea>d__.<>1__state = -1;
		<SpawnBgArea>d__.<>t__builder.Start<ArtemisQteProgressItem.<SpawnBgArea>d__63>(ref <SpawnBgArea>d__);
		return <SpawnBgArea>d__.<>t__builder.Task;
	}

	// Token: 0x0600779E RID: 30622 RVA: 0x001F522B File Offset: 0x001F342B
	[NullableContext(2)]
	public void SetCurrentPlayingSequenceName(string sequenceName)
	{
		this.AllAreaPlayingSequenceName = sequenceName;
	}

	// Token: 0x040039D1 RID: 14801
	private const int MIN_ANIM_TIME = 100;

	// Token: 0x040039D2 RID: 14802
	private const int PROGRESS_START_ANGLE = -53;

	// Token: 0x040039D3 RID: 14803
	private const int PROGRESS_END_ANGLE = 0;

	// Token: 0x040039D4 RID: 14804
	private const int PAUSE_TIME = 0;

	// Token: 0x040039D5 RID: 14805
	private static readonly int YAW_MAX_ANGLE = 720;

	// Token: 0x040039D6 RID: 14806
	protected int GamePlayId;

	// Token: 0x040039D7 RID: 14807
	protected ArtemisQteGameInfo GameInfo;

	// Token: 0x040039D8 RID: 14808
	[Nullable(2)]
	protected ArtemisQteRingInfo RingInfo;

	// Token: 0x040039D9 RID: 14809
	private readonly Rotator CurrentRotator = Rotator.Create();

	// Token: 0x040039DA RID: 14810
	private readonly Rotator CurrentFillAmountRotator = Rotator.Create();

	// Token: 0x040039DB RID: 14811
	private readonly Rotator AnimRotator = Rotator.Create();

	// Token: 0x040039DC RID: 14812
	private bool InAnim;

	// Token: 0x040039DD RID: 14813
	private int CurrentAnimTime;

	// Token: 0x040039DE RID: 14814
	private float AnimStartProgress;

	// Token: 0x040039DF RID: 14815
	private int AnimTime;

	// Token: 0x040039E0 RID: 14816
	private float ArrowActiveStartYawAngle;

	// Token: 0x040039E1 RID: 14817
	private float ArrowActiveEndYawAngle;

	// Token: 0x040039E2 RID: 14818
	protected EArtemisRotateMode RotateMode;

	// Token: 0x040039E3 RID: 14819
	protected float PeriodAlphaTotalTime;

	// Token: 0x040039E4 RID: 14820
	protected float PeriodAlphaCurrentTime;

	// Token: 0x040039E5 RID: 14821
	private readonly Dictionary<int, ArtemisQteRingSingleItem> QteAreaTextures = new Dictionary<int, ArtemisQteRingSingleItem>();

	// Token: 0x040039E6 RID: 14822
	private readonly Dictionary<int, ArtemisQteRingSingleItem> PerfectAreaTextures = new Dictionary<int, ArtemisQteRingSingleItem>();

	// Token: 0x040039E7 RID: 14823
	private readonly List<ArtemisQteRingSingleItem> CachedTexture = new List<ArtemisQteRingSingleItem>();

	// Token: 0x040039E8 RID: 14824
	[Nullable(2)]
	private string AllAreaPlayingSequenceName;

	// Token: 0x040039E9 RID: 14825
	[Nullable(2)]
	private string OncePlayingSequenceName;

	// Token: 0x040039EA RID: 14826
	private readonly List<ArtemisQteRingBgSingleItem> BgItemList = new List<ArtemisQteRingBgSingleItem>();

	// Token: 0x02007510 RID: 29968
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040286A6 RID: 165542
		public const int Setoff1Texture1 = 0;

		// Token: 0x040286A7 RID: 165543
		public const int Setoff1Texture2 = 1;

		// Token: 0x040286A8 RID: 165544
		public const int Setoff1Texture3 = 2;

		// Token: 0x040286A9 RID: 165545
		public const int ClickPointPnl = 3;

		// Token: 0x040286AA RID: 165546
		public const int ControlBar = 4;

		// Token: 0x040286AB RID: 165547
		public const int ProgressPercebtText = 5;

		// Token: 0x040286AC RID: 165548
		public const int RotationBarPnl = 6;

		// Token: 0x040286AD RID: 165549
		public const int PointRotationPnl = 7;

		// Token: 0x040286AE RID: 165550
		public const int PnlClickPointLayout = 8;
	}
}
