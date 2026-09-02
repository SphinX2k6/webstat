using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.EffectSave;
using UnrealEngine;

// Token: 0x02002DC3 RID: 11715
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicEffectSave : BulletLogicController<LogicDataEffectSave, object>
{
	// Token: 0x060179F1 RID: 96753 RVA: 0x006930D9 File Offset: 0x006912D9
	public BulletLogicEffectSave(LogicDataEffectSave logicController, Entity bullet) : base(logicController, bullet)
	{
	}

	// Token: 0x060179F2 RID: 96754 RVA: 0x006930E4 File Offset: 0x006912E4
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		if (ObjectUtils.SoftObjectReferenceValid<UEffectModelBase>(this.LogicController.Effect))
		{
			ControllerBase<EffectSaveController>.Instance.MarkEffectSave(this.LogicController.Effect.ToAssetPathName(), this.Bullet.GetBulletInfo().GetActorLocation(), this.Bullet.GetBulletInfo().GetActorRotation());
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Bullet;
		ELogAuthor author = ELogAuthor.HCW;
		string message = "配置路径错了";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("子弹ID", this.Bullet.GetBulletInfo().BulletRowName);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}
}
