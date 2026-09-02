using System;
using System.Runtime.CompilerServices;

// Token: 0x02003449 RID: 13385
[NullableContext(1)]
[Nullable(0)]
public class AnimHelp : CombatScriptSet
{
	// Token: 0x0601C149 RID: 115017 RVA: 0x00860ABC File Offset: 0x0085ECBC
	public AnimHelp()
	{
		this.Introduction = "\r\n        /** Welcome to use AnimHelp\r\n        *\r\n        *  你可以在这里找部分动画功能相关的调试指令\r\n        *\r\n        *  如下指令将获取到运行时实体编号为13的实体\r\n        *  EntitySystem.Get(13)\r\n        *  然后你最近修改了这个实体的动画蓝图，\r\n        *  虽然引擎初始化了它，但脚本层没有，所以它没有任何的脚本相关数据更新\r\n        *  你可以尝试将它重新走一遍脚本的初始化\r\n        *  输入下列指令:\r\n        *  EventSystem.EmitWithTarget(EntitySystem.Get(13), EEventName.CharChangeMeshAnim);\r\n        *  如果不是很方便你也可以输入\r\n        *  AnimHelp.ResetAnimInstanceCmd\r\n        *  点击【执行】代码将会执行指令\r\n        *  点击【解析命令】将会把短句的指令完整替换到具体指令，以方便修改。\r\n        *\r\n        *\r\n        *\r\n        *\r\n        *\r\n        *\r\n        */;";
		this.CombatScriptUnits.Add(this.ResetAnimInstanceCmd);
		this.CombatScriptUnits.Add(this.GetAnimInstanceCmd);
		foreach (CombatScriptUnit combatScriptUnit in this.CombatScriptUnits)
		{
			this.Introduction += combatScriptUnit.ToString();
		}
	}

	// Token: 0x0400E2CE RID: 58062
	public CombatScriptUnit ResetAnimInstanceCmd = new CombatScriptUnit("AnimHelp.ResetAnimInstanceCmd", "\r\nconst entityId = 15;\r\nEventSystem.EmitWithTarget(EntitySystem.Get(entityId), EEventName.CharChangeMeshAnim);", "重置动画蓝图", "");

	// Token: 0x0400E2CF RID: 58063
	public CombatScriptUnit GetAnimInstanceCmd = new CombatScriptUnit("AnimHelp.GetAnimInstanceCmd", "\r\nconst entityId = 15;\r\nconst animInstance = EntitySystem.Get(entityId).GetComponentByEnum(EComponent.CharacterAnimationComponent).MainAnimInstance;\r\nanimInstance.GetName();\r\n\r\n//以下是测试代码，删除【// + 中文】进行测试\r\n//布尔值修改 animInstance.bComponentStart = false;\r\n//旋转值修改 animInstance.LowerBodyRotator = new UE.Rotator(90,90,90);\r\n//向量值修改 animInstance.XXXXX = new UE.Vector(0,0,0);\r\n        ", "获取动画蓝图实例", "获取动画蓝图实例后，可进行动画蓝图变量的实时参数");
}
