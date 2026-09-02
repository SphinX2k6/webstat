using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002622 RID: 9762
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteRingMatchTapItem : CommonQteItemBase<CommonQteSingleClickContext>
{
	// Token: 0x0601333D RID: 78653 RVA: 0x0055516C File Offset: 0x0055336C
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
		}
	}

	// Token: 0x0601333E RID: 78654 RVA: 0x0055520C File Offset: 0x0055340C
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteRingMatchTapItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteRingMatchTapItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601333F RID: 78655 RVA: 0x00555250 File Offset: 0x00553450
	protected override void OnStart()
	{
		base.OnStart();
		this.PrefabItem = base.GetButton(0);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		UUIButtonComponent prefabItem = this.PrefabItem;
		if (prefabItem != null)
		{
			prefabItem.OnPointDownCallBack.Bind(delegate()
			{
				base.OnInputCallback(this.QteAction, InputDistributeDefine.EActionType.Press, null);
			});
		}
		base.SetUiActive(false);
	}

	// Token: 0x06013340 RID: 78656 RVA: 0x005552C2 File Offset: 0x005534C2
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		UUIButtonComponent prefabItem = this.PrefabItem;
		if (prefabItem != null)
		{
			prefabItem.OnPointDownCallBack.Unbind();
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.Clear();
	}

	// Token: 0x06013341 RID: 78657 RVA: 0x005552F0 File Offset: 0x005534F0
	protected override void OnRefreshActionUi(string action)
	{
		InputMultiKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.RefreshByActionOrAxis(new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = action
			}, false);
		}
		InputMultiKeyItem keyItem2 = this.KeyItem;
		if (keyItem2 == null)
		{
			return;
		}
		keyItem2.Show(null);
	}

	// Token: 0x06013342 RID: 78658 RVA: 0x00555321 File Offset: 0x00553521
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteSingleClickContext;
	}

	// Token: 0x06013343 RID: 78659 RVA: 0x0055532C File Offset: 0x0055352C
	[NullableContext(2)]
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_SingleClick scommonQte_SingleClick = uiConfig as SCommonQte_SingleClick;
		if (scommonQte_SingleClick != null)
		{
			this.WindowStart = scommonQte_SingleClick.ProgressResponseStart;
			this.WindowEnd = scommonQte_SingleClick.ProgressResponseEnd;
		}
	}

	// Token: 0x06013344 RID: 78660 RVA: 0x00555364 File Offset: 0x00553564
	protected override void OnPlayQteStart()
	{
		base.SetUiActive(true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		if (this.IsQteInteractive && !this.IsMobile)
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.Show(null);
		}
	}

	// Token: 0x06013345 RID: 78661 RVA: 0x005553BC File Offset: 0x005535BC
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			if (this.IsQteEnd || this.CommonQteContext == null)
			{
				return;
			}
			this.IsQteStart = true;
			this.IsQteInteractive = true;
			float? playRate = (this.CommonQteContext.Duration > 0f) ? new float?(1f / this.CommonQteContext.Duration * 1000f) : null;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Opportunity", false, playRate, false);
			}
			if (!this.IsMobile)
			{
				InputMultiKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.Show(null);
				return;
			}
		}
		else if (sequenceName == "Success" || sequenceName == "Fail" || sequenceName == "Close")
		{
			base.Destroy(null);
		}
	}

	// Token: 0x06013346 RID: 78662 RVA: 0x00555494 File Offset: 0x00553694
	protected override void OnInputPress()
	{
		CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext == null || !commonQteContext.IsResponsible())
		{
			return;
		}
		float duration = this.CommonQteContext.Duration;
		float num = (duration > 0f) ? (this.CommonQteContext.PassTime / duration) : 0f;
		if (num >= this.WindowStart && num <= this.WindowEnd)
		{
			this.CommonQteContext.Response();
			return;
		}
		this.CommonQteContext.QteFail();
	}

	// Token: 0x06013347 RID: 78663 RVA: 0x0055550C File Offset: 0x0055370C
	protected override void OnHandleQteEnd()
	{
		InputMultiKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.Hide(null);
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 != null)
		{
			levelSequencePlayer2.StopSequenceByKey("Opportunity", false, false);
		}
		CommonQteSingleClickContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null && commonQteContext.IsSuccess())
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 == null)
			{
				return;
			}
			levelSequencePlayer3.PlayLevelSequenceByName("Success", false, null, false);
			return;
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
			if (levelSequencePlayer4 == null)
			{
				return;
			}
			levelSequencePlayer4.PlayLevelSequenceByName("Fail", false, null, false);
			return;
		}
	}

	// Token: 0x06013348 RID: 78664 RVA: 0x005555AC File Offset: 0x005537AC
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext != null)
		{
			SCommonQte_SingleClick scommonQte_SingleClick = this.CommonQteContext.GetUiConfig() as SCommonQte_SingleClick;
			if (scommonQte_SingleClick != null)
			{
				SCommonQteButton uiconfig = scommonQte_SingleClick.UIConfig;
				UUIItem rootItem = this.RootItem;
				if (rootItem != null)
				{
					rootItem.SetAnchorAlign(uiconfig.AnchorHAlign, uiconfig.AnchorVAlign);
				}
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 != null)
				{
					rootItem2.SetAnchorOffset(uiconfig.AnchorOffset);
				}
				UUIItem rootItem3 = this.RootItem;
				if (rootItem3 != null)
				{
					FRotator anchorRotation = uiconfig.AnchorRotation;
					rootItem3.SetUIRelativeRotation(anchorRotation);
				}
				if (this.IsAttaching)
				{
					this.Reattach(this.CommonQteContext);
				}
			}
		}
	}

	// Token: 0x040095E2 RID: 38370
	private const string OPPORTUNITY_SEQUENCE = "Opportunity";

	// Token: 0x040095E3 RID: 38371
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040095E4 RID: 38372
	[Nullable(2)]
	private UUIButtonComponent PrefabItem;

	// Token: 0x040095E5 RID: 38373
	private float WindowStart = 0.7f;

	// Token: 0x040095E6 RID: 38374
	private float WindowEnd = 0.9f;

	// Token: 0x040095E7 RID: 38375
	[Nullable(2)]
	private InputMultiKeyItem KeyItem;

	// Token: 0x020089C2 RID: 35266
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E78E RID: 190350
		PrefabItem,
		// Token: 0x0402E78F RID: 190351
		HitZoneItem,
		// Token: 0x0402E790 RID: 190352
		SuccessItem,
		// Token: 0x0402E791 RID: 190353
		FailItem,
		// Token: 0x0402E792 RID: 190354
		KeyItem
	}
}
