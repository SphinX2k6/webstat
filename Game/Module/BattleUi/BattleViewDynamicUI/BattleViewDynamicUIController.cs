using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.BattleViewDynamicUI
{
	// Token: 0x0200612E RID: 24878
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class BattleViewDynamicUIController : UiControllerBase<BattleViewDynamicUIController>
	{
		// Token: 0x0603ED8B RID: 257419 RVA: 0x0101A1E1 File Offset: 0x010183E1
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603ED8C RID: 257420 RVA: 0x0101A1E4 File Offset: 0x010183E4
		protected override bool OnClear()
		{
			this.PendingUITypes.Clear();
			this.ClearAllDynamicUI();
			this.CurrentBattleView = null;
			return true;
		}

		// Token: 0x0603ED8D RID: 257421 RVA: 0x0101A1FF File Offset: 0x010183FF
		protected override bool OnLeaveLevel()
		{
			this.PendingUITypes.Clear();
			this.ClearAllDynamicUI();
			this.CurrentBattleView = null;
			return true;
		}

		// Token: 0x0603ED8E RID: 257422 RVA: 0x0101A21A File Offset: 0x0101841A
		public void RegisterBattleView(BattleView battleView)
		{
			this.CurrentBattleView = battleView;
			this.FlushPendingUITypes();
		}

		// Token: 0x0603ED8F RID: 257423 RVA: 0x0101A229 File Offset: 0x01018429
		public void UnregisterBattleView(BattleView battleView)
		{
			if (this.CurrentBattleView == battleView)
			{
				this.PendingUITypes.Clear();
				this.ClearAllDynamicUI();
				this.CurrentBattleView = null;
			}
		}

		// Token: 0x0603ED90 RID: 257424 RVA: 0x0101A24C File Offset: 0x0101844C
		public void TryCreateDynamicUI(EBattleViewDynamicUIType uiType)
		{
			BattleViewDynamicUIConfig battleViewDynamicUIConfig;
			if (!BattleViewDynamicUIDefine.BattleViewDynamicUIConfigMap.TryGetValue(uiType, out battleViewDynamicUIConfig))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.LXH;
				string message = "[BattleViewDynamicUI] 未找到对应配置，请在 BattleViewDynamicUIDefine 中注册";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uiType", uiType.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (string.IsNullOrEmpty(battleViewDynamicUIConfig.ResourceId))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.LXH;
				string message2 = "[BattleViewDynamicUI] resourceId 为空";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("uiType", uiType.ToString());
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			BattleView currentBattleView = this.CurrentBattleView;
			if (currentBattleView == null || currentBattleView.IsDestroyOrDestroying)
			{
				if (!this.PendingUITypes.Contains(uiType))
				{
					this.PendingUITypes.Add(uiType);
				}
				return;
			}
			if (this.DynamicUIMap.ContainsKey(uiType))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Battle;
				ELogAuthor author3 = ELogAuthor.LXH;
				string message3 = "[BattleViewDynamicUI] 该 uiType 已存在或正在加载中，忽略重复创建请求";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("uiType", uiType.ToString());
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return;
			}
			UUIItem dynamicUIRootItem = currentBattleView.GetDynamicUIRootItem(battleViewDynamicUIConfig.ChildType);
			if (dynamicUIRootItem == null || !dynamicUIRootItem.IsValid())
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Battle;
				ELogAuthor author4 = ELogAuthor.LXH;
				string message4 = "[BattleViewDynamicUI] GetDynamicUIRootItem 返回无效节点，请检查配置";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("uiType", uiType.ToString());
				instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				return;
			}
			this.DynamicUIMap[uiType] = new DynamicUIRecord
			{
				IsLoading = true
			};
			BattleViewDynamicUiBase panel = battleViewDynamicUIConfig.CreateUi();
			this.CreateDynamicUIAsync(uiType, battleViewDynamicUIConfig.ResourceId, dynamicUIRootItem, panel).Forget();
		}

		// Token: 0x0603ED91 RID: 257425 RVA: 0x0101A3D0 File Offset: 0x010185D0
		public void TryDestroyDynamicUI(EBattleViewDynamicUIType uiType)
		{
			DynamicUIRecord uiRecord;
			if (!this.DynamicUIMap.TryGetValue(uiType, out uiRecord))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.LXH;
				string message = "[BattleViewDynamicUI] TryDestroyDynamicUI：未找到对应实例，可能已销毁或从未创建";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uiType", uiType.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.DynamicUIMap.Remove(uiType);
			BattleViewDynamicUIController.DestroyUIFromRecord(uiRecord);
		}

		// Token: 0x0603ED92 RID: 257426 RVA: 0x0101A434 File Offset: 0x01018634
		public void ClearAllDynamicUI()
		{
			if (this.DynamicUIMap.Count == 0)
			{
				return;
			}
			this.IsClearing = true;
			foreach (DynamicUIRecord uiRecord in this.DynamicUIMap.Values)
			{
				BattleViewDynamicUIController.DestroyUIFromRecord(uiRecord);
			}
			this.DynamicUIMap.Clear();
			this.IsClearing = false;
		}

		// Token: 0x0603ED93 RID: 257427 RVA: 0x0101A4B0 File Offset: 0x010186B0
		private UniTask CreateDynamicUIAsync(EBattleViewDynamicUIType uiType, string resourceId, UUIItem parentItem, BattleViewDynamicUiBase panel)
		{
			BattleViewDynamicUIController.<CreateDynamicUIAsync>d__12 <CreateDynamicUIAsync>d__;
			<CreateDynamicUIAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDynamicUIAsync>d__.<>4__this = this;
			<CreateDynamicUIAsync>d__.uiType = uiType;
			<CreateDynamicUIAsync>d__.resourceId = resourceId;
			<CreateDynamicUIAsync>d__.parentItem = parentItem;
			<CreateDynamicUIAsync>d__.panel = panel;
			<CreateDynamicUIAsync>d__.<>1__state = -1;
			<CreateDynamicUIAsync>d__.<>t__builder.Start<BattleViewDynamicUIController.<CreateDynamicUIAsync>d__12>(ref <CreateDynamicUIAsync>d__);
			return <CreateDynamicUIAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ED94 RID: 257428 RVA: 0x0101A514 File Offset: 0x01018714
		private void OnUILoadCompleted(EBattleViewDynamicUIType uiType, BattleViewDynamicUiBase panel)
		{
			if (this.IsClearing)
			{
				if (!panel.IsDestroyOrDestroying)
				{
					panel.Destroy(null);
				}
				return;
			}
			if (!this.DynamicUIMap.ContainsKey(uiType))
			{
				if (!panel.IsDestroyOrDestroying)
				{
					panel.Destroy(null);
				}
				return;
			}
			if (panel.IsDestroyOrDestroying)
			{
				this.DynamicUIMap.Remove(uiType);
				return;
			}
			this.DynamicUIMap[uiType] = new DynamicUIRecord
			{
				Instance = panel,
				IsLoading = false
			};
		}

		// Token: 0x0603ED95 RID: 257429 RVA: 0x0101A58C File Offset: 0x0101878C
		private void FlushPendingUITypes()
		{
			if (this.PendingUITypes.Count == 0)
			{
				return;
			}
			EBattleViewDynamicUIType[] array = this.PendingUITypes.ToArray();
			this.PendingUITypes.Clear();
			foreach (EBattleViewDynamicUIType uiType in array)
			{
				this.TryCreateDynamicUI(uiType);
			}
		}

		// Token: 0x0603ED96 RID: 257430 RVA: 0x0101A5D8 File Offset: 0x010187D8
		private static void DestroyUIFromRecord(DynamicUIRecord uiRecord)
		{
			if (uiRecord.IsLoading || uiRecord.Instance == null)
			{
				return;
			}
			BattleViewDynamicUiBase instance = uiRecord.Instance;
			if (instance.IsDestroyOrDestroying)
			{
				return;
			}
			instance.Destroy(null);
		}

		// Token: 0x04023424 RID: 144420
		[Nullable(2)]
		private BattleView CurrentBattleView;

		// Token: 0x04023425 RID: 144421
		private readonly Dictionary<EBattleViewDynamicUIType, DynamicUIRecord> DynamicUIMap = new Dictionary<EBattleViewDynamicUIType, DynamicUIRecord>();

		// Token: 0x04023426 RID: 144422
		private bool IsClearing;

		// Token: 0x04023427 RID: 144423
		private readonly List<EBattleViewDynamicUIType> PendingUITypes = new List<EBattleViewDynamicUIType>();
	}
}
