using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Data.Level.ItemInspect;
using CSharpScript.Game.LevelGamePlay.ItemInspect.Effect;
using CSharpScript.Game.LevelGamePlay.ItemInspect.Point;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect
{
	// Token: 0x02006E46 RID: 28230
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ItemInspectModel : ModelBase<ItemInspectModel>
	{
		// Token: 0x06044826 RID: 280614 RVA: 0x011CF692 File Offset: 0x011CD892
		protected override bool OnInit()
		{
			this.UiTypeToViewMap[ETextUiType.Astrology] = EUiViewName.AstrologyItemInspectView;
			this.EffectCenter.Init();
			return true;
		}

		// Token: 0x06044827 RID: 280615 RVA: 0x011CF6B4 File Offset: 0x011CD8B4
		public void InitGlobalConfig(BP_ItemInspectGlobalConfig_C config)
		{
			this.InputSeedLimit = config.输入速度限制;
			this.RotateInterpSpeed = config.平滑插值旋转速度;
			this.ResetItemRotationSpeed = config.重置旋转速度;
			this.DarkStageMeshPath = config.压暗网格体.ToAssetPathName();
			this.DarkStageMaterialPath = config.压暗材质.ToAssetPathName();
			this.DarkStageScreenDepth = config.压暗屏幕深度;
			this.DarkStageAlpha = config.压暗不透明度;
			this.DarkStageBlendTime = config.压暗过渡时间;
			this.DarkStageBlendInterval = config.压暗过渡间隔;
			this.IsInitGlobal = true;
		}

		// Token: 0x06044828 RID: 280616 RVA: 0x011CF73E File Offset: 0x011CD93E
		public bool IsInitGlobalConfig()
		{
			return this.IsInitGlobal;
		}

		// Token: 0x06044829 RID: 280617 RVA: 0x011CF746 File Offset: 0x011CD946
		public float GetInputSeedLimit()
		{
			return this.InputSeedLimit;
		}

		// Token: 0x0604482A RID: 280618 RVA: 0x011CF74E File Offset: 0x011CD94E
		public float GetRotateInterpSpeed()
		{
			return this.RotateInterpSpeed;
		}

		// Token: 0x0604482B RID: 280619 RVA: 0x011CF756 File Offset: 0x011CD956
		public float GetResetItemRotationSpeed()
		{
			return this.ResetItemRotationSpeed;
		}

		// Token: 0x0604482C RID: 280620 RVA: 0x011CF75E File Offset: 0x011CD95E
		public string GetDarkStageMeshPath()
		{
			return this.DarkStageMeshPath;
		}

		// Token: 0x0604482D RID: 280621 RVA: 0x011CF766 File Offset: 0x011CD966
		public string GetDarkStageMaterialPath()
		{
			return this.DarkStageMaterialPath;
		}

		// Token: 0x0604482E RID: 280622 RVA: 0x011CF76E File Offset: 0x011CD96E
		public float GetDarkStageScreenDepth()
		{
			return this.DarkStageScreenDepth;
		}

		// Token: 0x0604482F RID: 280623 RVA: 0x011CF776 File Offset: 0x011CD976
		public float GetDarkStageAlpha()
		{
			return this.DarkStageAlpha;
		}

		// Token: 0x06044830 RID: 280624 RVA: 0x011CF77E File Offset: 0x011CD97E
		public float GetDarkStageBlendTime()
		{
			return this.DarkStageBlendTime;
		}

		// Token: 0x06044831 RID: 280625 RVA: 0x011CF786 File Offset: 0x011CD986
		public float GetDarkStageBlendInterval()
		{
			return this.DarkStageBlendInterval;
		}

		// Token: 0x06044832 RID: 280626 RVA: 0x011CF790 File Offset: 0x011CD990
		public void InitData(ETextUiType uiType, float inputSensitivity, ItemInspectRangeChecker rangeChecker, ItemInspectPointManager pointManager, [Nullable(2)] IItemInspectFinishEffect finishEffect, UTraceLineElement lineElement, [Nullable(2)] Action<bool> onFinish = null)
		{
			EUiViewName value;
			if (this.UiTypeToViewMap.TryGetValue(uiType, out value))
			{
				this.CurrentViewName = new EUiViewName?(value);
			}
			else
			{
				this.CurrentViewName = null;
			}
			this.DragSensitivity = inputSensitivity;
			this.GamePadSensitivity = inputSensitivity * 20f;
			this.RangeChecker = rangeChecker;
			this.PointManager = pointManager;
			this.StageLifecycleLocked = true;
			this.PendingEnterInitialStage = false;
			this.OnEnterInitialStageFinish = null;
			this.FinishEffect = finishEffect;
			this.LineElement = lineElement;
			this.OnFinishItemInspect = onFinish;
		}

		// Token: 0x06044833 RID: 280627 RVA: 0x011CF818 File Offset: 0x011CDA18
		public void ClearData()
		{
			this.CurItemId = 0;
			this.InputDirect.Reset();
			this.ResetDragRuntime();
			this.OnDragInteractSuccess = null;
			this.EffectCenter.ClearEffects();
			this.VisiblePoints.Clear();
			this.VisiblePointsPool.Clear();
			this.IsItemPrefabReady = false;
			this.IsOpenViewReady = false;
			this.RangeChecker = null;
			this.CurrentViewName = null;
			this.PointManager = null;
			this.StageLifecycleLocked = true;
			this.PendingEnterInitialStage = false;
			this.OnEnterInitialStageFinish = null;
			this.FinishEffect = null;
			this.LineElement = null;
			this.DragSensitivity = 0f;
			this.GamePadSensitivity = 0f;
			this.OnFinishItemInspect = null;
			this.ResettingItem = false;
			this.OnResetItemRotationFinish = null;
			this.FocusRotating = false;
			this.OnFocusRotationFinish = null;
			this.FocusRotationSpeedCurve = null;
			this.FocusRotationElapsedTime = 0f;
			this.OriginItemActor = null;
			AStaticMeshActor darkStageActor = this.DarkStageActor;
			if (darkStageActor != null && darkStageActor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("ItemInspect Clear", this.DarkStageActor, null);
			}
			this.DarkStageActor = null;
			this.DarkStageMaterial = null;
			TimerHandle darkStageBlendTimer = this.DarkStageBlendTimer;
			if (darkStageBlendTimer != null)
			{
				darkStageBlendTimer.Remove();
			}
			this.DarkStageBlendTimer = null;
		}

		// Token: 0x06044834 RID: 280628 RVA: 0x011CF954 File Offset: 0x011CDB54
		public void LoadPrefabReady()
		{
			this.IsItemPrefabReady = true;
		}

		// Token: 0x06044835 RID: 280629 RVA: 0x011CF95D File Offset: 0x011CDB5D
		public void OpenViewReady()
		{
			this.IsOpenViewReady = true;
		}

		// Token: 0x06044836 RID: 280630 RVA: 0x011CF966 File Offset: 0x011CDB66
		public bool IsInspectReady()
		{
			return this.IsItemPrefabReady && this.IsOpenViewReady;
		}

		// Token: 0x06044837 RID: 280631 RVA: 0x011CF978 File Offset: 0x011CDB78
		public EUiViewName? GetViewName()
		{
			return this.CurrentViewName;
		}

		// Token: 0x06044838 RID: 280632 RVA: 0x011CF980 File Offset: 0x011CDB80
		[NullableContext(2)]
		public ItemInspectRangeChecker GetRangeChecker()
		{
			return this.RangeChecker;
		}

		// Token: 0x06044839 RID: 280633 RVA: 0x011CF988 File Offset: 0x011CDB88
		[NullableContext(2)]
		public ItemInspectPointManager GetPointManager()
		{
			return this.PointManager;
		}

		// Token: 0x0604483A RID: 280634 RVA: 0x011CF990 File Offset: 0x011CDB90
		public bool IsStageLifecycleLocked()
		{
			return this.StageLifecycleLocked;
		}

		// Token: 0x0604483B RID: 280635 RVA: 0x011CF998 File Offset: 0x011CDB98
		public void SetStageLifecycleLocked(bool locked)
		{
			this.StageLifecycleLocked = locked;
		}

		// Token: 0x0604483C RID: 280636 RVA: 0x011CF9A1 File Offset: 0x011CDBA1
		public bool IsPendingEnterInitialStage()
		{
			return this.PendingEnterInitialStage;
		}

		// Token: 0x0604483D RID: 280637 RVA: 0x011CF9A9 File Offset: 0x011CDBA9
		public void RequestEnterInitialStage(Action onFinish)
		{
			this.PendingEnterInitialStage = true;
			this.OnEnterInitialStageFinish = onFinish;
		}

		// Token: 0x0604483E RID: 280638 RVA: 0x011CF9B9 File Offset: 0x011CDBB9
		[NullableContext(2)]
		public Action ConsumeEnterInitialStageRequest()
		{
			this.PendingEnterInitialStage = false;
			Action onEnterInitialStageFinish = this.OnEnterInitialStageFinish;
			this.OnEnterInitialStageFinish = null;
			return onEnterInitialStageFinish;
		}

		// Token: 0x0604483F RID: 280639 RVA: 0x011CF9CF File Offset: 0x011CDBCF
		public ItemInspectEffectCenter GetEffectCenter()
		{
			return this.EffectCenter;
		}

		// Token: 0x06044840 RID: 280640 RVA: 0x011CF9D7 File Offset: 0x011CDBD7
		public float GetDragSensitivity()
		{
			return this.DragSensitivity;
		}

		// Token: 0x06044841 RID: 280641 RVA: 0x011CF9DF File Offset: 0x011CDBDF
		public float GetGamePadSensitivity()
		{
			return this.GamePadSensitivity;
		}

		// Token: 0x06044842 RID: 280642 RVA: 0x011CF9E7 File Offset: 0x011CDBE7
		public int GetMaxValidPointCount()
		{
			ItemInspectPointManager pointManager = this.PointManager;
			if (pointManager == null)
			{
				return 0;
			}
			return pointManager.GetMaxValidCount();
		}

		// Token: 0x06044843 RID: 280643 RVA: 0x011CF9FA File Offset: 0x011CDBFA
		public int GetCheckedValidPointCount()
		{
			ItemInspectPointManager pointManager = this.PointManager;
			if (pointManager == null)
			{
				return 0;
			}
			return pointManager.GetCheckedValidCount();
		}

		// Token: 0x06044844 RID: 280644 RVA: 0x011CFA0D File Offset: 0x011CDC0D
		[NullableContext(2)]
		public IItemInspectFinishEffect GetFinishEffect()
		{
			return this.FinishEffect;
		}

		// Token: 0x06044845 RID: 280645 RVA: 0x011CFA15 File Offset: 0x011CDC15
		[NullableContext(2)]
		public UTraceLineElement GetLineElement()
		{
			return this.LineElement;
		}

		// Token: 0x06044846 RID: 280646 RVA: 0x011CFA1D File Offset: 0x011CDC1D
		[NullableContext(2)]
		public Action<bool> GetFinishCallback()
		{
			return this.OnFinishItemInspect;
		}

		// Token: 0x06044847 RID: 280647 RVA: 0x011CFA28 File Offset: 0x011CDC28
		public void ResetDragRuntime()
		{
			this.IsDragging = false;
			this.IsDragSucceed = false;
			this.IsDragSnapping = false;
			this.DragSnapElapsedSecond = 0f;
			this.DragSnapStartLocation.Reset();
			this.DragItemActor = null;
			this.DragTargetActor = null;
			this.DragTargetTagId = 0;
			this.DragCheckDistance = 0f;
			this.DragPlaneDepth = 0f;
			this.DragScreenPos.Reset();
			this.DragTargetScreenPos.Reset();
			this.DragGamepadInput.Reset();
		}

		// Token: 0x04026204 RID: 156164
		private const int GAME_PAD_SENSITIVITY = 20;

		// Token: 0x04026205 RID: 156165
		private bool IsInitGlobal;

		// Token: 0x04026206 RID: 156166
		private float InputSeedLimit;

		// Token: 0x04026207 RID: 156167
		private float RotateInterpSpeed;

		// Token: 0x04026208 RID: 156168
		private float ResetItemRotationSpeed;

		// Token: 0x04026209 RID: 156169
		private string DarkStageMeshPath = "";

		// Token: 0x0402620A RID: 156170
		private string DarkStageMaterialPath = "";

		// Token: 0x0402620B RID: 156171
		private float DarkStageScreenDepth;

		// Token: 0x0402620C RID: 156172
		private float DarkStageAlpha;

		// Token: 0x0402620D RID: 156173
		private float DarkStageBlendTime;

		// Token: 0x0402620E RID: 156174
		private float DarkStageBlendInterval;

		// Token: 0x0402620F RID: 156175
		private readonly Dictionary<ETextUiType, EUiViewName> UiTypeToViewMap = new Dictionary<ETextUiType, EUiViewName>();

		// Token: 0x04026210 RID: 156176
		private readonly ItemInspectEffectCenter EffectCenter = new ItemInspectEffectCenter();

		// Token: 0x04026211 RID: 156177
		public bool CloseSkipConfirmBox;

		// Token: 0x04026212 RID: 156178
		public bool OpenRangeDebug;

		// Token: 0x04026213 RID: 156179
		[Nullable(2)]
		public AActor OriginItemActor;

		// Token: 0x04026214 RID: 156180
		[Nullable(2)]
		public AStaticMeshActor DarkStageActor;

		// Token: 0x04026215 RID: 156181
		[Nullable(2)]
		public UMaterialInstanceDynamic DarkStageMaterial;

		// Token: 0x04026216 RID: 156182
		[Nullable(2)]
		public TimerHandle DarkStageBlendTimer;

		// Token: 0x04026217 RID: 156183
		public int CurItemId;

		// Token: 0x04026218 RID: 156184
		public bool ResettingItem;

		// Token: 0x04026219 RID: 156185
		[Nullable(2)]
		public Action OnResetItemRotationFinish;

		// Token: 0x0402621A RID: 156186
		public bool FocusRotating;

		// Token: 0x0402621B RID: 156187
		[Nullable(2)]
		public Action OnFocusRotationFinish;

		// Token: 0x0402621C RID: 156188
		public readonly Quat FocusTargetQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0402621D RID: 156189
		public float FocusRotationSpeed = 5f;

		// Token: 0x0402621E RID: 156190
		[Nullable(2)]
		public UCurveFloat FocusRotationSpeedCurve;

		// Token: 0x0402621F RID: 156191
		public float FocusRotationElapsedTime;

		// Token: 0x04026220 RID: 156192
		public readonly Vector2D InputDirect = Vector2D.Create();

		// Token: 0x04026221 RID: 156193
		public readonly Rotator TempRotator = Rotator.Create();

		// Token: 0x04026222 RID: 156194
		public readonly Rotator TempRotator2 = Rotator.Create();

		// Token: 0x04026223 RID: 156195
		public readonly Quat TargetQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04026224 RID: 156196
		public readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04026225 RID: 156197
		public readonly Vector TempVector = Vector.Create();

		// Token: 0x04026226 RID: 156198
		public readonly List<IItemInspectVisiblePointData> VisiblePoints = new List<IItemInspectVisiblePointData>();

		// Token: 0x04026227 RID: 156199
		public readonly List<IItemInspectVisiblePointData> VisiblePointsPool = new List<IItemInspectVisiblePointData>();

		// Token: 0x04026228 RID: 156200
		public bool IsDragging;

		// Token: 0x04026229 RID: 156201
		public bool IsDragSucceed;

		// Token: 0x0402622A RID: 156202
		public bool IsDragSnapping;

		// Token: 0x0402622B RID: 156203
		public float DragSnapElapsedSecond;

		// Token: 0x0402622C RID: 156204
		public readonly Vector DragSnapStartLocation = Vector.Create();

		// Token: 0x0402622D RID: 156205
		[Nullable(2)]
		public AActor DragItemActor;

		// Token: 0x0402622E RID: 156206
		[Nullable(2)]
		public AActor DragTargetActor;

		// Token: 0x0402622F RID: 156207
		public int DragTargetTagId;

		// Token: 0x04026230 RID: 156208
		public float DragCheckDistance;

		// Token: 0x04026231 RID: 156209
		public float DragPlaneDepth;

		// Token: 0x04026232 RID: 156210
		public readonly Vector DragStartLocation = Vector.Create();

		// Token: 0x04026233 RID: 156211
		public readonly Vector2D DragScreenPos = Vector2D.Create();

		// Token: 0x04026234 RID: 156212
		public readonly Vector2D DragTargetScreenPos = Vector2D.Create();

		// Token: 0x04026235 RID: 156213
		public readonly Vector2D DragGamepadInput = Vector2D.Create();

		// Token: 0x04026236 RID: 156214
		[Nullable(2)]
		public Action<int> OnDragInteractSuccess;

		// Token: 0x04026237 RID: 156215
		private bool IsItemPrefabReady;

		// Token: 0x04026238 RID: 156216
		private bool IsOpenViewReady;

		// Token: 0x04026239 RID: 156217
		[Nullable(2)]
		private ItemInspectRangeChecker RangeChecker;

		// Token: 0x0402623A RID: 156218
		private EUiViewName? CurrentViewName;

		// Token: 0x0402623B RID: 156219
		[Nullable(2)]
		private ItemInspectPointManager PointManager;

		// Token: 0x0402623C RID: 156220
		private bool StageLifecycleLocked = true;

		// Token: 0x0402623D RID: 156221
		private bool PendingEnterInitialStage;

		// Token: 0x0402623E RID: 156222
		[Nullable(2)]
		private Action OnEnterInitialStageFinish;

		// Token: 0x0402623F RID: 156223
		private float DragSensitivity;

		// Token: 0x04026240 RID: 156224
		private float GamePadSensitivity;

		// Token: 0x04026241 RID: 156225
		[Nullable(2)]
		private IItemInspectFinishEffect FinishEffect;

		// Token: 0x04026242 RID: 156226
		[Nullable(2)]
		private UTraceLineElement LineElement;

		// Token: 0x04026243 RID: 156227
		[Nullable(2)]
		private Action<bool> OnFinishItemInspect;
	}
}
