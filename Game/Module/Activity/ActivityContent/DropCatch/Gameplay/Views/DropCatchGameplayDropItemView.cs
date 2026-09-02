using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x020068FC RID: 26876
	public class DropCatchGameplayDropItemView : UiPanelBase
	{
		// Token: 0x06042C64 RID: 273508 RVA: 0x01122F54 File Offset: 0x01121154
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUINiagara)),
				new ValueTuple<int, Type>(2, typeof(UUINiagara)),
				new ValueTuple<int, Type>(3, typeof(UUINiagara)),
				new ValueTuple<int, Type>(4, typeof(UUINiagara))
			};
		}

		// Token: 0x06042C65 RID: 273509 RVA: 0x01122FDC File Offset: 0x011211DC
		protected override void OnBeforeShow()
		{
			int num = (int)this.OpenParam;
			DropCatchDropItem? dropCatchDropItemById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchDropItemById(num);
			if (dropCatchDropItemById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到掉落物配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (!StringUtils.IsEmpty(dropCatchDropItemById.Value.Icon))
			{
				base.TrySetSpriteByPath(dropCatchDropItemById.Value.Icon, base.GetSprite(0), true, null, null);
			}
			this.RefreshTail((EDropCatchDropItemNiagaraType)dropCatchDropItemById.Value.NiagaraType);
		}

		// Token: 0x06042C66 RID: 273510 RVA: 0x01123090 File Offset: 0x01121290
		private void RefreshTail(EDropCatchDropItemNiagaraType type)
		{
			base.GetUiNiagara(1).SetUIActive(type == EDropCatchDropItemNiagaraType.Nor);
			base.GetUiNiagara(2).SetUIActive(type == EDropCatchDropItemNiagaraType.Mid);
			base.GetUiNiagara(3).SetUIActive(type == EDropCatchDropItemNiagaraType.High);
			base.GetUiNiagara(4).SetUIActive(type == EDropCatchDropItemNiagaraType.Bad);
		}
	}
}
