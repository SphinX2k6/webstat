using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;
using CSharpScript.Game.KuroSimpleCombat;

// Token: 0x02000F8B RID: 3979
public class TowerDefenseInputController
{
	// Token: 0x06006530 RID: 25904 RVA: 0x00195228 File Offset: 0x00193428
	public static bool OnStart()
	{
		return true;
	}

	// Token: 0x06006531 RID: 25905 RVA: 0x0019522B File Offset: 0x0019342B
	public static bool OnStop()
	{
		TowerDefenseInputController.RemoveInputLayer();
		return true;
	}

	// Token: 0x06006532 RID: 25906 RVA: 0x00195234 File Offset: 0x00193434
	[NullableContext(2)]
	private static TowerDefenseInputLayer GetInputLayer()
	{
		EntityHandle possessedPlayerEntity = TowerDefensePlayerController.GetPossessedPlayerEntity();
		if (possessedPlayerEntity != null)
		{
			return ControllerBase<InputController>.Instance.GetInputLayer(possessedPlayerEntity.Id, EInputLayer.TowerDefense) as TowerDefenseInputLayer;
		}
		return null;
	}

	// Token: 0x06006533 RID: 25907 RVA: 0x00195264 File Offset: 0x00193464
	public static bool AddInputLayer()
	{
		TowerDefenseInputLayer towerDefenseInputLayer = TowerDefenseInputController.GetInputLayer();
		if (towerDefenseInputLayer != null)
		{
			TowerDefenseInputController.RemoveInputLayer();
		}
		towerDefenseInputLayer = (ControllerBase<InputController>.Instance.CreateInputLayer(EInputLayer.TowerDefense) as TowerDefenseInputLayer);
		if (towerDefenseInputLayer != null)
		{
			EntityHandle possessedPlayerEntity = TowerDefensePlayerController.GetPossessedPlayerEntity();
			if (possessedPlayerEntity != null)
			{
				ControllerBase<InputController>.Instance.AddInputLayer(possessedPlayerEntity.Id, towerDefenseInputLayer);
			}
			else
			{
				KscLog.Warn(KscLog.EModule.Input, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防输入层加入异常,无法绑定实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return true;
		}
		KscLog.Warn(KscLog.EModule.Input, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防输入层加入异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x06006534 RID: 25908 RVA: 0x001952F4 File Offset: 0x001934F4
	public static bool RemoveInputLayer()
	{
		TowerDefenseInputLayer inputLayer = TowerDefenseInputController.GetInputLayer();
		if (inputLayer != null)
		{
			ControllerBase<InputController>.Instance.RemoveInputLayer(inputLayer);
			inputLayer.Clear();
			return true;
		}
		KscLog.Warn(KscLog.EModule.Input, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "塔防输入层移除异常", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}
}
