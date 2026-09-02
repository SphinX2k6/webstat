using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AB1 RID: 6833
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DamageUiManager : Singleton<DamageUiManager>
{
	// Token: 0x0600C3CB RID: 50123 RVA: 0x00339C38 File Offset: 0x00337E38
	public void Initialize()
	{
		this.MinDamageOffsetScale = (float)ConfigCommonParamById.GetIntConfig("MinDamageOffsetScale").Value / 100f;
		this.MaxDamageOffsetScale = (float)ConfigCommonParamById.GetIntConfig("MaxDamageOffsetScale").Value / 100f;
		this.MinDamageOffsetDistance = (float)ConfigCommonParamById.GetIntConfig("MinDamageOffsetDistance").Value;
		this.MaxDamageOffsetDistance = (float)ConfigCommonParamById.GetIntConfig("MaxDamageOffsetDistance").Value;
		this.DamagePositionCache = global::Vector.Create();
		this.DamageTextConfigList = ConfigBase<DamageUiConfig>.Instance.GetAllDamageTextConfig();
		IReadOnlyList<DamageTextArea> allDamageTextArea = ConfigBase<DamageUiConfig>.Instance.GetAllDamageTextArea();
		if (allDamageTextArea != null)
		{
			foreach (DamageTextArea value in allDamageTextArea)
			{
				this.DamageTextAreaMap.Add(value.Id, value);
			}
		}
		this.InitializeDamageViewData();
	}

	// Token: 0x0600C3CC RID: 50124 RVA: 0x00339D2C File Offset: 0x00337F2C
	public void InitializeDamageViewData()
	{
		if (this.DamageTextConfigList == null)
		{
			return;
		}
		foreach (DamageText damageTextConfig in this.DamageTextConfigList)
		{
			DamageViewData damageViewData = new DamageViewData();
			damageViewData.Initialize(damageTextConfig);
			this.DamageViewDataMap.Add(damageTextConfig.Id, damageViewData);
			if (!StringUtils.IsEmpty(damageViewData.CriticalNiagaraPath))
			{
				int criticalNiagaraId;
				if (!this.CriticalNiagaraPathMap.TryGetValue(damageViewData.CriticalNiagaraPath, out criticalNiagaraId))
				{
					damageViewData.CriticalNiagaraId = this.CriticalNiagaraId;
					this.CriticalNiagaraPathMap.Add(damageViewData.CriticalNiagaraPath, damageViewData.CriticalNiagaraId);
					this.CriticalNiagaraId++;
				}
				else
				{
					damageViewData.CriticalNiagaraId = criticalNiagaraId;
				}
			}
		}
	}

	// Token: 0x0600C3CD RID: 50125 RVA: 0x00339E00 File Offset: 0x00338000
	public void ClearDamageViewData()
	{
		this.DamageViewDataMap.Clear();
	}

	// Token: 0x0600C3CE RID: 50126 RVA: 0x00339E10 File Offset: 0x00338010
	[NullableContext(2)]
	public DamageViewData GetDamageViewData(int damageTextId)
	{
		DamageViewData result;
		if (this.DamageViewDataMap.TryGetValue(damageTextId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600C3CF RID: 50127 RVA: 0x00339E30 File Offset: 0x00338030
	public void PreloadDamageView()
	{
		for (int i = this.UnusedDamageViewList.Count; i < 21; i++)
		{
			DamageView damageView = new DamageView();
			damageView.Init();
			this.TotalDamageViewNum++;
			this.UnusedDamageViewList.Add(damageView);
		}
	}

	// Token: 0x0600C3D0 RID: 50128 RVA: 0x00339E7C File Offset: 0x0033807C
	public void ApplyDamage(float damage, int elementId, FVectorDouble damagePosition, Entity target, bool bCritical, bool bCure, int damageTextId = -1, string damageText = "", int damageTextAreaId = 0)
	{
		if (!this.IsDamageViewVisible)
		{
			return;
		}
		if (!target.Active)
		{
			return;
		}
		if (damageTextId < 0)
		{
			return;
		}
		if (damageTextId == 1 && bCure && damage == 0f)
		{
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			return;
		}
		bool flag = getCurrentEntity.Id == target.Id;
		if (this.EnableOptimization || damageTextId == 2)
		{
			if (this.UeDamageUiManagerInternal != null)
			{
				int num = (int)Math.Floor((double)Math.Abs(damage));
				int damageConfigId = this.MakeDamageTextId(elementId, bCure, (float)num, damageTextId);
				string damageText2 = damageText;
				if (!StringUtils.IsEmpty(damageText))
				{
					string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById(damageText);
					damageText2 = (ConfigBase<TextConfig>.Instance.GetMultiTextByKey(textContentIdById) ?? " ");
				}
				UDamageUiManager ueDamageUiManagerInternal = this.UeDamageUiManagerInternal;
				FDamageInfo fdamageInfo = new FDamageInfo(num, damageConfigId, damagePosition, flag, bCritical, bCure, damageText2, 0f);
				ueDamageUiManagerInternal.AddDamageInfo(fdamageInfo);
				return;
			}
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.CFT, "产生性能伤害飘字时，缺少ueDamageUiManager", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		DamageInfo damageInfo;
		if (this.UnusedDamageInfoList.Count > 0)
		{
			int index = this.UnusedDamageInfoList.Count - 1;
			damageInfo = this.UnusedDamageInfoList[index];
			this.UnusedDamageInfoList.RemoveAt(index);
		}
		else
		{
			damageInfo = new DamageInfo();
		}
		damageInfo.Damage = damage;
		damageInfo.ElementId = elementId;
		damageInfo.DamagePosition = new FVectorDouble?(damagePosition);
		damageInfo.IsOwnPlayer = flag;
		damageInfo.IsCritical = bCritical;
		damageInfo.IsCure = bCure;
		damageInfo.DamageTextId = damageTextId;
		damageInfo.DamageText = damageText;
		damageInfo.DamageTextAreaId = damageTextAreaId;
		damageInfo.EntityId = target.Id;
		damageInfo.EnableOptimization = false;
		damageInfo.Valid = true;
		if (flag)
		{
			global::Vector actorLocationProxy = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy;
			if (actorLocationProxy != null)
			{
				damageInfo.BaseLocation.FromUeVector(actorLocationProxy);
			}
			else
			{
				damageInfo.BaseLocation.Reset();
			}
		}
		this.DamageInfoQueue.Push(damageInfo);
	}

	// Token: 0x0600C3D1 RID: 50129 RVA: 0x0033A064 File Offset: 0x00338264
	private unsafe void ApplyDamageInner(DamageInfo damageInfo, [Nullable(new byte[]
	{
		2,
		1
	})] List<DamageInfo> mergeDamageInfoList = null)
	{
		if (!this.IsDamageViewVisible)
		{
			return;
		}
		int num = (int)Math.Floor((double)Math.Abs(damageInfo.Damage));
		int num2 = this.MakeDamageTextId(damageInfo.ElementId, damageInfo.IsCure, (float)num, damageInfo.DamageTextId);
		if (num2 < 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "[DamageText]产生伤害飘字时，伤害飘字Id无效";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("textId", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("elementId", damageInfo.ElementId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("bCure", damageInfo.IsCure);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("damageTextId", damageInfo.DamageTextId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		global::Vector damagePositionCache = this.DamagePositionCache;
		FVectorDouble value = damageInfo.DamagePosition.Value;
		damagePositionCache.DeepCopy(value);
		DamageViewData damageViewData = this.GetDamageViewData(num2);
		if (damageViewData == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Battle;
			ELogAuthor author2 = ELogAuthor.CFT;
			string message2 = "找不到对应的伤害飘字配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("伤害飘字Id", num2);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.ProjectWorldLocationToScreenPosition(damageInfo.DamagePosition.Value) == null)
		{
			return;
		}
		DamageView damageView;
		if (this.UnusedDamageViewList.Count > 0)
		{
			int index = this.UnusedDamageViewList.Count - 1;
			damageView = this.UnusedDamageViewList[index];
			this.UnusedDamageViewList.RemoveAt(index);
		}
		else
		{
			damageView = new DamageView();
			damageView.Init();
			this.TotalDamageViewNum++;
		}
		this.DamageViewSet.Add(damageView);
		damageView.InitializeData((float)num, this.DamagePositionCache, damageInfo.BaseLocation, damageViewData, damageInfo.IsCritical, damageInfo.IsCure, damageInfo.IsOwnPlayer, damageInfo.DamageText, damageInfo.DamageTextAreaId, mergeDamageInfoList);
	}

	// Token: 0x0600C3D2 RID: 50130 RVA: 0x0033A264 File Offset: 0x00338464
	public void Tick(float delta)
	{
		float delta2 = delta * Singleton<Time>.Instance.InverseSelfCenteredTimeDilation;
		if (this.TimeScaleEnable)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null && getCurrentEntity.Valid)
			{
				WorldEntity entity = getCurrentEntity.Entity;
				float? num;
				if (entity == null)
				{
					num = null;
				}
				else
				{
					CharacterTimeScaleComponent component = entity.GetComponent<CharacterTimeScaleComponent>();
					num = ((component != null) ? new float?(component.CurrentTimeScale) : null);
				}
				float? num2 = num;
				float valueOrDefault = num2.GetValueOrDefault(1f);
				foreach (DamageView damageView in this.DamageViewSet)
				{
					damageView.SetTimeScale(valueOrDefault);
				}
			}
		}
		foreach (DamageView damageView2 in this.DamageViewSet)
		{
			damageView2.Tick(delta2);
		}
		int num3 = 0;
		while (num3 < 1 && !this.DamageInfoQueue.Empty)
		{
			DamageInfo damageInfo = this.DamageInfoQueue.Pop();
			if (!damageInfo.Valid)
			{
				num3--;
				this.UnusedDamageInfoList.Add(damageInfo);
			}
			else
			{
				if (!ModelBase<CharacterModel>.Instance.IsValid(damageInfo.EntityId))
				{
					List<DamageInfo> list = new List<DamageInfo>();
					for (int i = 0; i < this.DamageInfoQueue.Size; i++)
					{
						DamageInfo damageInfo2 = this.DamageInfoQueue.Get(i);
						if (damageInfo2.EntityId == damageInfo.EntityId)
						{
							list.Add(damageInfo2);
							damageInfo2.Valid = false;
						}
					}
					this.ApplyDamageInner(damageInfo, list);
				}
				else
				{
					this.ApplyDamageInner(damageInfo, null);
				}
				this.UnusedDamageInfoList.Add(damageInfo);
			}
			num3++;
		}
		if (this.UeDamageUiManager != null)
		{
			global::Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
			UDamageUiManager ueDamageUiManager = this.UeDamageUiManager;
			float num4 = delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
			FVectorDouble fvectorDouble = cameraLocation.ToUeVector(false);
			ueDamageUiManager.Update(num4, fvectorDouble, Global.CharacterController);
		}
	}

	// Token: 0x0600C3D3 RID: 50131 RVA: 0x0033A488 File Offset: 0x00338688
	private int MakeDamageTextId(int elementId, bool bCure, float damage, int damageTextId = -1)
	{
		int result;
		if (damageTextId != 0 && damageTextId != -1 && damageTextId != 2)
		{
			result = damageTextId;
		}
		else if (damage == 0f)
		{
			result = 9;
		}
		else if (elementId > 0)
		{
			result = elementId;
		}
		else if (bCure)
		{
			result = 8;
		}
		else
		{
			result = 10;
		}
		return result;
	}

	// Token: 0x0600C3D4 RID: 50132 RVA: 0x0033A4CC File Offset: 0x003386CC
	public FVector2D? ProjectWorldLocationToScreenPosition(FVectorDouble worldLocation)
	{
		if (!UGameplayStatics.D_ProjectWorldToScreen(Global.CharacterController, worldLocation, ref this.ResultDamagePositionRef, false))
		{
			return null;
		}
		FVector2D resultDamagePositionRef = this.ResultDamagePositionRef;
		float x = resultDamagePositionRef.X;
		float y = resultDamagePositionRef.Y;
		if (float.IsNaN(x) || float.IsNaN(y) || !float.IsFinite(x) || !float.IsFinite(y))
		{
			return null;
		}
		return new FVector2D?(resultDamagePositionRef);
	}

	// Token: 0x0600C3D5 RID: 50133 RVA: 0x0033A53D File Offset: 0x0033873D
	public FVector2D ScreenPositionToLguiPosition(FVector2D screenPosition)
	{
		return Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler().ConvertPositionFromViewportToLGUICanvas(screenPosition);
	}

	// Token: 0x0600C3D6 RID: 50134 RVA: 0x0033A555 File Offset: 0x00338755
	public void RemoveDamageView(DamageView damageView)
	{
		if (this.DamageViewSet.Contains(damageView))
		{
			damageView.ClearData();
			this.DamageViewSet.Remove(damageView);
			this.UnusedDamageViewList.Add(damageView);
		}
	}

	// Token: 0x0600C3D7 RID: 50135 RVA: 0x0033A584 File Offset: 0x00338784
	public void OnEditorPlatformChanged()
	{
		foreach (DamageView damageView in this.DamageViewSet)
		{
			damageView.RefreshFontSize();
		}
		foreach (DamageView damageView2 in this.UnusedDamageViewList)
		{
			damageView2.RefreshFontSize();
		}
	}

	// Token: 0x0600C3D8 RID: 50136 RVA: 0x0033A614 File Offset: 0x00338814
	public void SetDamageTimeScaleEnable(bool bEnable)
	{
		this.TimeScaleEnable = bEnable;
		if (!this.TimeScaleEnable)
		{
			foreach (DamageView damageView in this.DamageViewSet)
			{
				damageView.SetTimeScale(1f);
			}
		}
	}

	// Token: 0x0600C3D9 RID: 50137 RVA: 0x0033A678 File Offset: 0x00338878
	public void SetDamageViewVisible(bool bVisible)
	{
		this.IsDamageViewVisible = bVisible;
		if (this.UeDamageUiManagerInternal != null)
		{
			this.UeDamageUiManagerInternal.bDamageViewVisible = this.IsDamageViewVisible;
			if (!bVisible)
			{
				this.UeDamageUiManagerInternal.ClearDamageInfo();
			}
		}
	}

	// Token: 0x0600C3DA RID: 50138 RVA: 0x0033A6A8 File Offset: 0x003388A8
	public bool GetDamageViewVisible()
	{
		return this.IsDamageViewVisible;
	}

	// Token: 0x0600C3DB RID: 50139 RVA: 0x0033A6B0 File Offset: 0x003388B0
	[return: Nullable(2)]
	public UGeometryHandle PlayDamageNumBatch(string damageTextString, FVector2D uiPosition, FColor textColor, int animType = 1)
	{
		return null;
	}

	// Token: 0x0600C3DC RID: 50140 RVA: 0x0033A6B3 File Offset: 0x003388B3
	public void UpdateDamageLocation(UGeometryHandle geometryHandle, FVector2D uiPosition, int animType = 1)
	{
	}

	// Token: 0x0600C3DD RID: 50141 RVA: 0x0033A6B8 File Offset: 0x003388B8
	public int EnableDamageViewOptimization()
	{
		int enableOptimizationIdGen = this.EnableOptimizationIdGen;
		this.EnableOptimizationIdGen = enableOptimizationIdGen + 1;
		int num = enableOptimizationIdGen;
		this.EnableOptimizationHandleSet.Add(num);
		this.EnableOptimization = true;
		return num;
	}

	// Token: 0x0600C3DE RID: 50142 RVA: 0x0033A6EC File Offset: 0x003388EC
	public void DisableDamageViewOptimization(int id)
	{
		this.EnableOptimizationHandleSet.Remove(id);
		bool enableOptimization = this.EnableOptimizationHandleSet.Count > 0;
		this.EnableOptimization = enableOptimization;
	}

	// Token: 0x0600C3DF RID: 50143 RVA: 0x0033A71C File Offset: 0x0033891C
	public DamageTextArea? GetDamageTextAreaById(int id)
	{
		DamageTextArea value;
		if (this.DamageTextAreaMap.TryGetValue(id, out value))
		{
			return new DamageTextArea?(value);
		}
		return null;
	}

	// Token: 0x0600C3E0 RID: 50144 RVA: 0x0033A74C File Offset: 0x0033894C
	public void OnLeaveLevel()
	{
		foreach (DamageView damageView in this.DamageViewSet)
		{
			damageView.ClearData();
			damageView.Destroy(null);
		}
		this.DamageViewSet.Clear();
		foreach (DamageView damageView2 in this.UnusedDamageViewList)
		{
			damageView2.Destroy(null);
		}
		this.UnusedDamageViewList.Clear();
		this.TotalDamageViewNum = 0;
		this.DamageInfoQueue.Clear();
		this.UnusedDamageInfoList.Clear();
		this.CriticalNiagaraList.Clear();
		this.CriticalNiagaraId = 0;
	}

	// Token: 0x0600C3E1 RID: 50145 RVA: 0x0033A828 File Offset: 0x00338A28
	public void Clear()
	{
		this.EnableOptimizationHandleSet.Clear();
		this.EnableOptimization = false;
	}

	// Token: 0x0600C3E2 RID: 50146 RVA: 0x0033A83C File Offset: 0x00338A3C
	public void InitUeDamageUiManager(UDamageUiManager ueDamageUiManager)
	{
		if (this.UeDamageConfig != null)
		{
			ueDamageUiManager.InitDamageConfig(this.UeDamageConfig);
		}
		if (this.DamageDynamicBatchActor == null)
		{
			return;
		}
		if (this.DamageViewActor == null)
		{
			return;
		}
		ueDamageUiManager.InitAllRes(Singleton<UiLayer>.Instance.GetBattleViewUnit(0), this.DamageDynamicBatchActor, this.DamageViewActor, this.HideDamageCritEffect ? 1 : 20, Singleton<Info>.Instance.IsMobilePlatform());
		foreach (DamageText damageText in this.DamageTextConfigList)
		{
			if (damageText.UseForOptimization)
			{
				int id = damageText.Id;
				DamageViewData damageViewData;
				if (this.DamageViewDataMap.TryGetValue(id, out damageViewData))
				{
					FDamageViewData fdamageViewData = new FDamageViewData();
					fdamageViewData.ConfigId = damageViewData.ConfigId;
					fdamageViewData.MinRandomOffsetX = (int)damageViewData.MinRandomOffsetX;
					fdamageViewData.MinRandomOffsetY = (int)damageViewData.MinRandomOffsetY;
					fdamageViewData.MaxRandomOffsetX = (int)damageViewData.MaxRandomOffsetX;
					fdamageViewData.MaxRandomOffsetY = (int)damageViewData.MaxRandomOffsetY;
					fdamageViewData.TextColor = damageViewData.TextColor.Value;
					fdamageViewData.CritTextColor = damageViewData.CriticalTextColor.Value;
					fdamageViewData.OutlineColor = damageViewData.StrokeColor.Value;
					fdamageViewData.CritOutlineColor = damageViewData.CriticalStrokeColor.Value;
					fdamageViewData.CritNiagaraType = (this.HideDamageCritEffect ? -1 : damageViewData.CriticalNiagaraId);
					int num;
					fdamageViewData.OwnDamageAnimType = (this.DamageAnimMap.TryGetValue(damageViewData.DamageTextConfig.Value.OwnDamageSequence, out num) ? num : 0);
					int num2;
					fdamageViewData.OwnCritDamageAnimType = (this.DamageAnimMap.TryGetValue(damageViewData.DamageTextConfig.Value.OwnCriticalDamageSequence, out num2) ? num2 : 0);
					int num3;
					fdamageViewData.MonsterDamageAnimType = (this.DamageAnimMap.TryGetValue(damageViewData.DamageTextConfig.Value.MonsterDamageSequence, out num3) ? num3 : 0);
					int num4;
					fdamageViewData.MonsterCritDamageAnimType = (this.DamageAnimMap.TryGetValue(damageViewData.DamageTextConfig.Value.MonsterCriticalDamageSequence, out num4) ? num4 : 0);
					int num5;
					fdamageViewData.TextDamageAnimType = (this.DamageAnimMap.TryGetValue(damageViewData.DamageTextConfig.Value.DamageTextSequence, out num5) ? num5 : 0);
					fdamageViewData.IconPath = damageViewData.DamageTextConfig.Value.Icon;
					fdamageViewData.IconScale = damageViewData.DamageTextConfig.Value.IconScale;
					ueDamageUiManager.AddDamageViewData(fdamageViewData);
				}
			}
		}
		foreach (UNiagaraSystem critNiagara in this.CriticalNiagaraList)
		{
			ueDamageUiManager.AddCritNiagara(critNiagara);
		}
		ueDamageUiManager.bDamageViewVisible = this.IsDamageViewVisible;
	}

	// Token: 0x0600C3E3 RID: 50147 RVA: 0x0033AB50 File Offset: 0x00338D50
	public UniTask PreloadAsync()
	{
		DamageUiManager.<PreloadAsync>d__57 <PreloadAsync>d__;
		<PreloadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadAsync>d__.<>4__this = this;
		<PreloadAsync>d__.<>1__state = -1;
		<PreloadAsync>d__.<>t__builder.Start<DamageUiManager.<PreloadAsync>d__57>(ref <PreloadAsync>d__);
		return <PreloadAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C3E4 RID: 50148 RVA: 0x0033AB94 File Offset: 0x00338D94
	private UniTask LoadCriticalNiagara(string path, int id)
	{
		DamageUiManager.<LoadCriticalNiagara>d__58 <LoadCriticalNiagara>d__;
		<LoadCriticalNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadCriticalNiagara>d__.<>4__this = this;
		<LoadCriticalNiagara>d__.path = path;
		<LoadCriticalNiagara>d__.id = id;
		<LoadCriticalNiagara>d__.<>1__state = -1;
		<LoadCriticalNiagara>d__.<>t__builder.Start<DamageUiManager.<LoadCriticalNiagara>d__58>(ref <LoadCriticalNiagara>d__);
		return <LoadCriticalNiagara>d__.<>t__builder.Task;
	}

	// Token: 0x0600C3E5 RID: 50149 RVA: 0x0033ABE8 File Offset: 0x00338DE8
	private UniTask LoadDamageDynamicBatchActor()
	{
		DamageUiManager.<LoadDamageDynamicBatchActor>d__59 <LoadDamageDynamicBatchActor>d__;
		<LoadDamageDynamicBatchActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadDamageDynamicBatchActor>d__.<>4__this = this;
		<LoadDamageDynamicBatchActor>d__.<>1__state = -1;
		<LoadDamageDynamicBatchActor>d__.<>t__builder.Start<DamageUiManager.<LoadDamageDynamicBatchActor>d__59>(ref <LoadDamageDynamicBatchActor>d__);
		return <LoadDamageDynamicBatchActor>d__.<>t__builder.Task;
	}

	// Token: 0x0600C3E6 RID: 50150 RVA: 0x0033AC2C File Offset: 0x00338E2C
	private UniTask LoadDamageViewActor()
	{
		DamageUiManager.<LoadDamageViewActor>d__60 <LoadDamageViewActor>d__;
		<LoadDamageViewActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadDamageViewActor>d__.<>4__this = this;
		<LoadDamageViewActor>d__.<>1__state = -1;
		<LoadDamageViewActor>d__.<>t__builder.Start<DamageUiManager.<LoadDamageViewActor>d__60>(ref <LoadDamageViewActor>d__);
		return <LoadDamageViewActor>d__.<>t__builder.Task;
	}

	// Token: 0x0600C3E7 RID: 50151 RVA: 0x0033AC70 File Offset: 0x00338E70
	private string GetDamageBatchResourceId()
	{
		int curInstSubType = this.GetCurInstSubType();
		if (curInstSubType < 0)
		{
			return "UiItem_DamageView_Num_Prefab";
		}
		return DamageUiDefine.inst2DamageDynamicBatch.GetValueOrDefault((EDungeonSubType)curInstSubType) ?? "UiItem_DamageView_Num_Prefab";
	}

	// Token: 0x0600C3E8 RID: 50152 RVA: 0x0033ACA4 File Offset: 0x00338EA4
	private string GetDamageViewResourceId()
	{
		int curInstSubType = this.GetCurInstSubType();
		if (curInstSubType < 0)
		{
			return "UiItem_DamageView_Sim_Prefab";
		}
		return DamageUiDefine.inst2DamageView.GetValueOrDefault((EDungeonSubType)curInstSubType) ?? "UiItem_DamageView_Sim_Prefab";
	}

	// Token: 0x0600C3E9 RID: 50153 RVA: 0x0033ACD8 File Offset: 0x00338ED8
	private int GetCurInstSubType()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		if (config == null)
		{
			return -1;
		}
		return config.Value.InstSubType;
	}

	// Token: 0x0600C3EA RID: 50154 RVA: 0x0033AD18 File Offset: 0x00338F18
	public string FormatDamageNumber(float num)
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (instanceId == 0)
		{
			return num.ToString();
		}
		if (instanceId == this.CachedCurInstId)
		{
			IDamageNumFormatRule cachedDamageNumFormatRule = this.CachedDamageNumFormatRule;
			return ((cachedDamageNumFormatRule != null) ? cachedDamageNumFormatRule.FormatNumber(num) : null) ?? num.ToString();
		}
		this.CachedCurInstId = instanceId;
		this.CachedDamageNumFormatRule = null;
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		if (config == null)
		{
			return num.ToString();
		}
		int instSubType = config.Value.InstSubType;
		IDamageNumFormatRule valueOrDefault = DamageNumFormatRuleDefine.DamageNumFormatRuleMap.GetValueOrDefault((EDungeonSubType)instSubType);
		if (valueOrDefault == null)
		{
			return num.ToString();
		}
		this.CachedDamageNumFormatRule = valueOrDefault;
		return valueOrDefault.FormatNumber(num);
	}

	// Token: 0x17000FFF RID: 4095
	// (get) Token: 0x0600C3EB RID: 50155 RVA: 0x0033ADC4 File Offset: 0x00338FC4
	[Nullable(2)]
	public UDamageUiManager UeDamageUiManager
	{
		[NullableContext(2)]
		get
		{
			return this.UeDamageUiManagerInternal;
		}
	}

	// Token: 0x0600C3EC RID: 50156 RVA: 0x0033ADCC File Offset: 0x00338FCC
	public void StartUeDamageUiManager()
	{
		if (this.UeDamageUiManagerInternal != null)
		{
			return;
		}
		this.UeDamageUiManagerInternal = UDamageUiManager.CreateInstance(GlobalData.World);
		if (this.DamageDynamicBatchActor == null)
		{
			this.PreloadAsync().ContinueWith(delegate()
			{
				if (this.UeDamageUiManagerInternal != null)
				{
					this.InitUeDamageUiManager(this.UeDamageUiManagerInternal);
					return;
				}
				this.DamageDynamicBatchActor = null;
				this.DamageViewActor = null;
			});
			return;
		}
		this.InitUeDamageUiManager(this.UeDamageUiManagerInternal);
	}

	// Token: 0x0600C3ED RID: 50157 RVA: 0x0033AE1F File Offset: 0x0033901F
	public void StopUeDamageUiManager()
	{
		if (this.UeDamageUiManagerInternal != null)
		{
			UDamageUiManager.DestroyInstance();
			this.UeDamageUiManagerInternal = null;
		}
		this.UeDamageConfig = null;
		this.HideDamageCritEffect = false;
		this.DamageDynamicBatchActor = null;
		this.DamageViewActor = null;
	}

	// Token: 0x0600C3EE RID: 50158 RVA: 0x0033AE54 File Offset: 0x00339054
	public void SetUeDamageConfig(FDamageConfig config, bool hideDamageCritEffect = false)
	{
		if (this.UeDamageUiManager != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "UeDamageUiManager已经初始化过，此时再设置DamageConfig不会生效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.UeDamageConfig = config;
		this.HideDamageCritEffect = hideDamageCritEffect;
	}

	// Token: 0x0600C3EF RID: 50159 RVA: 0x0033AE94 File Offset: 0x00339094
	public void UpdateKscWorld()
	{
		UDamageUiManager ueDamageUiManager = this.UeDamageUiManager;
		if (ueDamageUiManager == null)
		{
			return;
		}
		ueDamageUiManager.UpdateKscWorld();
	}

	// Token: 0x04005DE7 RID: 24039
	private const int PRELOAD_DAMAGE_VIEW_COUNT = 21;

	// Token: 0x04005DE8 RID: 24040
	private const int MAX_DAMAGE_PER_FRAME = 1;

	// Token: 0x04005DE9 RID: 24041
	private readonly Queue<DamageInfo> DamageInfoQueue = new Queue<DamageInfo>(4);

	// Token: 0x04005DEA RID: 24042
	private readonly List<DamageInfo> UnusedDamageInfoList = new List<DamageInfo>();

	// Token: 0x04005DEB RID: 24043
	public int TotalDamageViewNum;

	// Token: 0x04005DEC RID: 24044
	private readonly HashSet<DamageView> DamageViewSet = new HashSet<DamageView>();

	// Token: 0x04005DED RID: 24045
	private readonly List<DamageView> UnusedDamageViewList = new List<DamageView>();

	// Token: 0x04005DEE RID: 24046
	private readonly Dictionary<int, DamageViewData> DamageViewDataMap = new Dictionary<int, DamageViewData>();

	// Token: 0x04005DEF RID: 24047
	private bool IsDamageViewVisible = true;

	// Token: 0x04005DF0 RID: 24048
	public float MinDamageOffsetScale;

	// Token: 0x04005DF1 RID: 24049
	public float MaxDamageOffsetScale;

	// Token: 0x04005DF2 RID: 24050
	public float MinDamageOffsetDistance;

	// Token: 0x04005DF3 RID: 24051
	public float MaxDamageOffsetDistance;

	// Token: 0x04005DF4 RID: 24052
	[Nullable(2)]
	public global::Vector DamagePositionCache;

	// Token: 0x04005DF5 RID: 24053
	[Nullable(2)]
	private IReadOnlyList<DamageText> DamageTextConfigList;

	// Token: 0x04005DF6 RID: 24054
	private readonly Dictionary<int, DamageTextArea> DamageTextAreaMap = new Dictionary<int, DamageTextArea>();

	// Token: 0x04005DF7 RID: 24055
	private FVector2D ResultDamagePositionRef = new FVector2D();

	// Token: 0x04005DF8 RID: 24056
	private bool TimeScaleEnable;

	// Token: 0x04005DF9 RID: 24057
	public bool EnableOptimization;

	// Token: 0x04005DFA RID: 24058
	private int EnableOptimizationIdGen;

	// Token: 0x04005DFB RID: 24059
	private readonly HashSet<int> EnableOptimizationHandleSet = new HashSet<int>();

	// Token: 0x04005DFC RID: 24060
	private readonly Dictionary<string, int> CriticalNiagaraPathMap = new Dictionary<string, int>();

	// Token: 0x04005DFD RID: 24061
	private readonly List<UNiagaraSystem> CriticalNiagaraList = new List<UNiagaraSystem>();

	// Token: 0x04005DFE RID: 24062
	private int CriticalNiagaraId;

	// Token: 0x04005DFF RID: 24063
	[Nullable(2)]
	private AUIBaseActor DamageDynamicBatchActor;

	// Token: 0x04005E00 RID: 24064
	[Nullable(2)]
	private AUIBaseActor DamageViewActor;

	// Token: 0x04005E01 RID: 24065
	public readonly Dictionary<string, int> DamageAnimMap = new Dictionary<string, int>
	{
		{
			"",
			0
		},
		{
			"Ani_OwnDamageSequence",
			1
		},
		{
			"Ani_OwnCriticalDamageSequence",
			2
		},
		{
			"Ani_MonsterDamageSequence",
			3
		},
		{
			"Ani_MonsterCriticalDamageSequence",
			4
		},
		{
			"Ani_BuffSequence",
			5
		},
		{
			"Ani_SpecialDamage",
			6
		},
		{
			"Ani_SpecialCriticalDamage",
			7
		},
		{
			"Ani_SpecialPathDamage",
			8
		},
		{
			"Ani_HeavyDamage",
			9
		},
		{
			"Ani_HeavyCriticalDamage",
			10
		},
		{
			"Ani_OwnShieldCoverSequence",
			11
		},
		{
			"Ani_Heal",
			12
		}
	};

	// Token: 0x04005E02 RID: 24066
	private readonly Stat TickStat1 = Stat.Create("DamageUiManager.TickStat1", "", "");

	// Token: 0x04005E03 RID: 24067
	[Nullable(2)]
	private UDamageUiManager UeDamageUiManagerInternal;

	// Token: 0x04005E04 RID: 24068
	[Nullable(2)]
	private FDamageConfig UeDamageConfig;

	// Token: 0x04005E05 RID: 24069
	public bool HideDamageCritEffect;

	// Token: 0x04005E06 RID: 24070
	private int CachedCurInstId;

	// Token: 0x04005E07 RID: 24071
	[Nullable(2)]
	private IDamageNumFormatRule CachedDamageNumFormatRule;
}
