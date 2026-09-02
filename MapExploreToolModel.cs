using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x0200223A RID: 8762
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MapExploreToolModel : ModelBase<MapExploreToolModel>
{
	// Token: 0x060108B0 RID: 67760 RVA: 0x00486788 File Offset: 0x00484988
	protected override bool OnInit()
	{
		this.MapSkillToPhantomSkill.Add(ERouletteSkillId.临时传送, ERouletteExploreId.临时传送);
		this.MapSkillToPhantomSkill.Add(ERouletteSkillId.声匣探测, ERouletteExploreId.声匣探测);
		this.MapSkillToPhantomSkill.Add(ERouletteSkillId.物资探测, ERouletteExploreId.物资探测);
		this.RespCodeToTipsId.Add(ERouletteExploreId.临时传送, new Dictionary<ErrorCode, EMapExploreToolCheckTipId>
		{
			{
				ErrorCode.ErrPlayerNotInBigWorld,
				EMapExploreToolCheckTipId.IllegalExploreToolUsingPos
			},
			{
				ErrorCode.ErrInFighting,
				EMapExploreToolCheckTipId.InFight
			},
			{
				ErrorCode.ErrNotHostPlayer,
				EMapExploreToolCheckTipId.NotHost
			},
			{
				ErrorCode.ErrConsumeNotEnough,
				EMapExploreToolCheckTipId.TempTeleporterCostNotEnough
			}
		});
		this.RespCodeToTipsId.Add(ERouletteExploreId.声匣探测, new Dictionary<ErrorCode, EMapExploreToolCheckTipId>
		{
			{
				ErrorCode.ErrPlayerNotInBigWorld,
				EMapExploreToolCheckTipId.IllegalExploreToolUsingPos
			},
			{
				ErrorCode.ErrInFighting,
				EMapExploreToolCheckTipId.InFight
			},
			{
				ErrorCode.ErrNotHostPlayer,
				EMapExploreToolCheckTipId.NotHost
			},
			{
				ErrorCode.ErrNotHaveCountryAccess,
				EMapExploreToolCheckTipId.NotHaveCountryAccess
			},
			{
				ErrorCode.ErrSkillIsEffect,
				EMapExploreToolCheckTipId.SoundBoxUseReachLimit
			},
			{
				ErrorCode.ErrNoSoundBox,
				EMapExploreToolCheckTipId.Exolore_ShengXiaNoDetect
			},
			{
				ErrorCode.SoundBoxExploreFull,
				EMapExploreToolCheckTipId.SoundBoxAllCollected
			},
			{
				ErrorCode.ErrConsumeNotEnough,
				EMapExploreToolCheckTipId.SoundBoxDetectorCostNotEnough
			}
		});
		this.RespCodeToTipsId.Add(ERouletteExploreId.物资探测, new Dictionary<ErrorCode, EMapExploreToolCheckTipId>
		{
			{
				ErrorCode.ErrPlayerNotInBigWorld,
				EMapExploreToolCheckTipId.IllegalExploreToolUsingPos
			},
			{
				ErrorCode.ErrInFighting,
				EMapExploreToolCheckTipId.InFight
			},
			{
				ErrorCode.ErrNotHostPlayer,
				EMapExploreToolCheckTipId.NotHost
			},
			{
				ErrorCode.ErrNotHaveCountryAccess,
				EMapExploreToolCheckTipId.NotHaveCountryAccess
			}
		});
		this.SkillToNotEnoughTipsId.Add(ERouletteExploreId.临时传送, EMapExploreToolCheckTipId.TempTeleporterCostNotEnough);
		this.SkillToNotEnoughTipsId.Add(ERouletteExploreId.声匣探测, EMapExploreToolCheckTipId.SoundBoxDetectorCostNotEnough);
		this.SkillToSuccessRespCode.Add(ERouletteExploreId.声匣探测, new HashSet<ErrorCode>
		{
			ErrorCode.Success,
			ErrorCode.ErrSkillIsEffect
		});
		this.SkillToSuccessRespCode.Add(ERouletteExploreId.物资探测, new HashSet<ErrorCode>
		{
			ErrorCode.Success,
			ErrorCode.ErrTreasureBoxAllActive
		});
		this.SkillToSuccessRespCode.Add(ERouletteExploreId.临时传送, new HashSet<ErrorCode>
		{
			ErrorCode.Success
		});
		this.SkillToCheckPassRespCode.Add(ERouletteExploreId.声匣探测, new HashSet<ErrorCode>
		{
			ErrorCode.ExploreToolNotConfirm
		});
		this.SkillToCheckPassRespCode.Add(ERouletteExploreId.物资探测, new HashSet<ErrorCode>
		{
			ErrorCode.ExploreToolNotConfirm,
			ErrorCode.ErrTreasureBoxAllActive
		});
		this.SkillToCheckPassRespCode.Add(ERouletteExploreId.临时传送, new HashSet<ErrorCode>
		{
			ErrorCode.ExploreToolNotConfirm
		});
		this.CharExploreSkillIsBusy = false;
		Singleton<EventSystem>.Instance.Add<DynamicMarkCreateInfo>(EEventName.CreateMapMark, new Action<DynamicMarkCreateInfo>(this.OnCreateMapMark));
		Singleton<EventSystem>.Instance.Add<EMarkType, int>(EEventName.RemoveMapMark, new Action<EMarkType, int>(this.OnRemoveMapMark));
		return true;
	}

	// Token: 0x060108B1 RID: 67761 RVA: 0x00486A18 File Offset: 0x00484C18
	protected override bool OnClear()
	{
		this.MapSkillToPhantomSkill.Clear();
		this.RespCodeToTipsId.Clear();
		this.SkillToNotEnoughTipsId.Clear();
		this.SkillToSuccessRespCode.Clear();
		this.SkillToExploreToolPlaceNum.Clear();
		this.CharExploreSkillIsBusy = false;
		Singleton<EventSystem>.Instance.Remove(EEventName.CreateMapMark, new Action<DynamicMarkCreateInfo>(this.OnCreateMapMark));
		Singleton<EventSystem>.Instance.Remove(EEventName.RemoveMapMark, new Action<EMarkType, int>(this.OnRemoveMapMark));
		return true;
	}

	// Token: 0x060108B2 RID: 67762 RVA: 0x00486A9C File Offset: 0x00484C9C
	protected override bool OnLeaveLevel()
	{
		this.CharExploreSkillIsBusy = false;
		return true;
	}

	// Token: 0x060108B3 RID: 67763 RVA: 0x00486AA6 File Offset: 0x00484CA6
	protected override bool OnChangeMode()
	{
		return true;
	}

	// Token: 0x060108B4 RID: 67764 RVA: 0x00486AAC File Offset: 0x00484CAC
	private void OnCreateMapMark(DynamicMarkCreateInfo info)
	{
		switch (info.MarkType)
		{
		case EMarkType.TemporaryTeleport:
		{
			int markCountByType = ModelBase<MapModel>.Instance.GetMarkCountByType(info.MarkType);
			this.SetToolPlaceNum(ERouletteExploreId.临时传送, markCountByType, true);
			return;
		}
		case EMarkType.SoundBox:
		case EMarkType.CalmingWindBell:
		{
			int markCountByType2 = ModelBase<MapModel>.Instance.GetMarkCountByType(EMarkType.SoundBox);
			int markCountByType3 = ModelBase<MapModel>.Instance.GetMarkCountByType(EMarkType.CalmingWindBell);
			this.SetToolPlaceNum(ERouletteExploreId.声匣探测, markCountByType2 + markCountByType3, true);
			break;
		}
		case EMarkType.TreasureBoxDetector:
		{
			int markCountByType4 = ModelBase<MapModel>.Instance.GetMarkCountByType(info.MarkType);
			this.SetToolPlaceNum(ERouletteExploreId.物资探测, markCountByType4, true);
			return;
		}
		case EMarkType.TreasureBox:
		case EMarkType.FixedSceneGameplay:
		case EMarkType.LandscapeMark:
			break;
		default:
			return;
		}
	}

	// Token: 0x060108B5 RID: 67765 RVA: 0x00486B50 File Offset: 0x00484D50
	private void OnRemoveMapMark(EMarkType markType, int markId)
	{
		switch (markType)
		{
		case EMarkType.TemporaryTeleport:
		{
			int markCountByType = ModelBase<MapModel>.Instance.GetMarkCountByType(markType);
			this.SetToolPlaceNum(ERouletteExploreId.临时传送, markCountByType, false);
			return;
		}
		case EMarkType.SoundBox:
		case EMarkType.CalmingWindBell:
		{
			int markCountByType2 = ModelBase<MapModel>.Instance.GetMarkCountByType(EMarkType.SoundBox);
			int markCountByType3 = ModelBase<MapModel>.Instance.GetMarkCountByType(EMarkType.CalmingWindBell);
			this.SetToolPlaceNum(ERouletteExploreId.声匣探测, markCountByType2 + markCountByType3, false);
			break;
		}
		case EMarkType.TreasureBoxDetector:
		{
			int markCountByType4 = ModelBase<MapModel>.Instance.GetMarkCountByType(markType);
			this.SetToolPlaceNum(ERouletteExploreId.物资探测, markCountByType4, false);
			return;
		}
		case EMarkType.TreasureBox:
		case EMarkType.FixedSceneGameplay:
		case EMarkType.LandscapeMark:
			break;
		default:
			return;
		}
	}

	// Token: 0x060108B6 RID: 67766 RVA: 0x00486BE0 File Offset: 0x00484DE0
	public ERouletteExploreId? GetPhantomSkillIdBySkillId(int skillId)
	{
		ERouletteExploreId value;
		if (this.MapSkillToPhantomSkill.TryGetValue((ERouletteSkillId)skillId, out value))
		{
			return new ERouletteExploreId?(value);
		}
		return null;
	}

	// Token: 0x060108B7 RID: 67767 RVA: 0x00486C10 File Offset: 0x00484E10
	public EMapExploreToolCheckTipId? GetRespTipsId(MapExploreToolUsingInfo usingInfo, ExploreToolResponse response)
	{
		Dictionary<ErrorCode, EMapExploreToolCheckTipId> dictionary;
		EMapExploreToolCheckTipId value;
		if (this.RespCodeToTipsId.TryGetValue((ERouletteExploreId)usingInfo.PhantomSkillId, out dictionary) && response.Content.HasValue && dictionary.TryGetValue(response.GetErrorCode(), out value))
		{
			return new EMapExploreToolCheckTipId?(value);
		}
		return null;
	}

	// Token: 0x060108B8 RID: 67768 RVA: 0x00486C64 File Offset: 0x00484E64
	public EMapExploreToolCheckTipId? GetNotEnoughTipsId(MapExploreToolUsingInfo usingInfo)
	{
		EMapExploreToolCheckTipId value;
		if (this.SkillToNotEnoughTipsId.TryGetValue((ERouletteExploreId)usingInfo.PhantomSkillId, out value))
		{
			return new EMapExploreToolCheckTipId?(value);
		}
		return null;
	}

	// Token: 0x060108B9 RID: 67769 RVA: 0x00486C98 File Offset: 0x00484E98
	public EConfirmBoxConfigId? GetConfirmBoxId(MapExploreToolUsingInfo usingInfo, ExploreToolResponse response = null)
	{
		bool flag = response == null;
		switch (usingInfo.PhantomSkillId)
		{
		case 1010:
			if (flag)
			{
				return new EConfirmBoxConfigId?(this.IsToolReachPlaceLimit((ERouletteExploreId)usingInfo.PhantomSkillId) ? EConfirmBoxConfigId.UseTempTeleportPointerAtLimit : EConfirmBoxConfigId.UseTempTeleportPointer);
			}
			return null;
		case 1011:
			if (!flag)
			{
				if (this.IsRespMeanCheckPass(usingInfo, response))
				{
					return new EConfirmBoxConfigId?(EConfirmBoxConfigId.UseSoundBoxDetector);
				}
				return null;
			}
			else
			{
				if (!this.IsToolReachPlaceLimit((ERouletteExploreId)usingInfo.PhantomSkillId))
				{
					return new EConfirmBoxConfigId?(EConfirmBoxConfigId.UseSoundBoxDetector);
				}
				return null;
			}
			break;
		case 1012:
			if (!flag)
			{
				return null;
			}
			if (!this.IsToolReachPlaceLimit((ERouletteExploreId)usingInfo.PhantomSkillId))
			{
				return null;
			}
			return new EConfirmBoxConfigId?(EConfirmBoxConfigId.UseTreasureBoxDetectorAtLimit);
		default:
			return null;
		}
	}

	// Token: 0x060108BA RID: 67770 RVA: 0x00486D7C File Offset: 0x00484F7C
	public bool ShowCostConfirmBox(MapExploreToolUsingInfo usingInfo, ExploreToolResponse response = null)
	{
		bool flag = response == null;
		switch (usingInfo.PhantomSkillId)
		{
		case 1010:
			if (flag)
			{
				return true;
			}
			break;
		case 1011:
			if (!flag && this.IsRespMeanCheckPass(usingInfo, response))
			{
				return true;
			}
			break;
		case 1012:
			if (flag)
			{
				return true;
			}
			break;
		}
		return false;
	}

	// Token: 0x060108BB RID: 67771 RVA: 0x00486DCC File Offset: 0x00484FCC
	public bool IsRespMeanSuccess(MapExploreToolUsingInfo usingInfo, ExploreToolResponse response)
	{
		HashSet<ErrorCode> hashSet;
		return this.SkillToSuccessRespCode.TryGetValue((ERouletteExploreId)usingInfo.PhantomSkillId, out hashSet) && response.Content.HasValue && hashSet.Contains(response.GetErrorCode());
	}

	// Token: 0x060108BC RID: 67772 RVA: 0x00486E10 File Offset: 0x00485010
	public bool IsRespMeanCheckPass(MapExploreToolUsingInfo usingInfo, ExploreToolResponse response)
	{
		HashSet<ErrorCode> hashSet;
		return this.SkillToCheckPassRespCode.TryGetValue((ERouletteExploreId)usingInfo.PhantomSkillId, out hashSet) && response.Content.HasValue && hashSet.Contains(response.GetErrorCode());
	}

	// Token: 0x060108BD RID: 67773 RVA: 0x00486E54 File Offset: 0x00485054
	public unsafe void SetCharExploreSkillBusy(bool isBusy)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "[MapExploreTool] 设置CharExploreSkillBusy";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("OldVal", this.CharExploreSkillIsBusy);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NewVal", isBusy);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.CharExploreSkillIsBusy = isBusy;
	}

	// Token: 0x060108BE RID: 67774 RVA: 0x00486ECA File Offset: 0x004850CA
	public bool GetCharExploreSkillBusy()
	{
		return this.CharExploreSkillIsBusy;
	}

	// Token: 0x060108BF RID: 67775 RVA: 0x00486ED4 File Offset: 0x004850D4
	public int? GetToolPlaceLimit(ERouletteExploreId phantomSkillId)
	{
		switch (phantomSkillId)
		{
		case ERouletteExploreId.临时传送:
			return new int?(ConfigBase<RouletteConfig>.Instance.GetTempTeleporterPlaceLimit());
		case ERouletteExploreId.声匣探测:
			return new int?(ConfigBase<RouletteConfig>.Instance.GetSoundBoxPlaceLimit());
		case ERouletteExploreId.物资探测:
			return new int?(ConfigBase<RouletteConfig>.Instance.GetTreasureBoxDetectorPlaceLimit());
		default:
			return null;
		}
	}

	// Token: 0x060108C0 RID: 67776 RVA: 0x00486F34 File Offset: 0x00485134
	public bool IsToolHasPlaceLimit(ERouletteExploreId phantomSkillId)
	{
		return this.GetToolPlaceLimit(phantomSkillId) != null;
	}

	// Token: 0x060108C1 RID: 67777 RVA: 0x00486F58 File Offset: 0x00485158
	public bool IsToolReachPlaceLimit(ERouletteExploreId phantomSkillId)
	{
		int? toolPlaceLimit = this.GetToolPlaceLimit(phantomSkillId);
		if (toolPlaceLimit == null)
		{
			return false;
		}
		int? toolPlaceNum = this.GetToolPlaceNum(phantomSkillId);
		return toolPlaceNum != null && toolPlaceNum.Value >= toolPlaceLimit.Value;
	}

	// Token: 0x060108C2 RID: 67778 RVA: 0x00486F9C File Offset: 0x0048519C
	public int? GetToolPlaceNum(ERouletteExploreId phantomSkillId)
	{
		int value;
		if (this.SkillToExploreToolPlaceNum.TryGetValue(phantomSkillId, out value))
		{
			return new int?(value);
		}
		return null;
	}

	// Token: 0x060108C3 RID: 67779 RVA: 0x00486FCC File Offset: 0x004851CC
	public unsafe void SetToolPlaceNum(ERouletteExploreId phantomSkillId, int placeNum, bool isAdd)
	{
		int? num = null;
		int value;
		if (this.SkillToExploreToolPlaceNum.TryGetValue(phantomSkillId, out value))
		{
			num = new int?(value);
		}
		if (num != null && placeNum == num.Value)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "[MapExploreTool] 设置ToolPlaceNum";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PhantomSkillId", phantomSkillId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlaceNum", placeNum);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.SkillToExploreToolPlaceNum.ContainsKey(phantomSkillId))
		{
			this.SkillToExploreToolPlaceNum[phantomSkillId] = placeNum;
		}
		else
		{
			this.SkillToExploreToolPlaceNum.Add(phantomSkillId, placeNum);
		}
		Singleton<EventSystem>.Instance.Emit<ERouletteExploreId, int>(EEventName.OnMapExploreToolPlaceNumUpdated, phantomSkillId, placeNum);
	}

	// Token: 0x04008226 RID: 33318
	private readonly Dictionary<ERouletteSkillId, ERouletteExploreId> MapSkillToPhantomSkill = new Dictionary<ERouletteSkillId, ERouletteExploreId>();

	// Token: 0x04008227 RID: 33319
	private readonly Dictionary<ERouletteExploreId, Dictionary<ErrorCode, EMapExploreToolCheckTipId>> RespCodeToTipsId = new Dictionary<ERouletteExploreId, Dictionary<ErrorCode, EMapExploreToolCheckTipId>>();

	// Token: 0x04008228 RID: 33320
	private readonly Dictionary<ERouletteExploreId, EMapExploreToolCheckTipId> SkillToNotEnoughTipsId = new Dictionary<ERouletteExploreId, EMapExploreToolCheckTipId>();

	// Token: 0x04008229 RID: 33321
	private readonly Dictionary<ERouletteExploreId, HashSet<ErrorCode>> SkillToSuccessRespCode = new Dictionary<ERouletteExploreId, HashSet<ErrorCode>>();

	// Token: 0x0400822A RID: 33322
	private readonly Dictionary<ERouletteExploreId, HashSet<ErrorCode>> SkillToCheckPassRespCode = new Dictionary<ERouletteExploreId, HashSet<ErrorCode>>();

	// Token: 0x0400822B RID: 33323
	private bool CharExploreSkillIsBusy;

	// Token: 0x0400822C RID: 33324
	private readonly Dictionary<ERouletteExploreId, int> SkillToExploreToolPlaceNum = new Dictionary<ERouletteExploreId, int>();
}
