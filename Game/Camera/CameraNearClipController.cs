using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200709C RID: 28828
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CameraNearClipController : ControllerBase<CameraNearClipController>
	{
		// Token: 0x06045DCB RID: 286155 RVA: 0x0124B814 File Offset: 0x01249A14
		public CameraNearClipController()
		{
			this.CameraNearClipConfigList = new PriorityQueue<CameraNearClipConfig>(new Comparison<CameraNearClipConfig>(this.CompareCameraNearClipConfigPriority));
		}

		// Token: 0x06045DCC RID: 286156 RVA: 0x0124B849 File Offset: 0x01249A49
		private int CompareCameraNearClipConfigPriority(CameraNearClipConfig a, CameraNearClipConfig b)
		{
			if (a.Priority == b.Priority)
			{
				return -1;
			}
			return b.Priority - a.Priority;
		}

		// Token: 0x06045DCD RID: 286157 RVA: 0x0124B868 File Offset: 0x01249A68
		public int EnableRelativeNearClip(int priority, float distance)
		{
			CameraNearClipConfig cameraNearClipConfig = new CameraNearClipConfig(priority);
			cameraNearClipConfig.SetRelativeNearClip(ECameraRelativeNearClipTargetType.CameraTarget, distance);
			this.CameraNearClipConfigList.Push(cameraNearClipConfig);
			this.CameraNearClipConfigMap[cameraNearClipConfig.Id] = cameraNearClipConfig;
			this.UpdateCameraNearClip();
			return cameraNearClipConfig.Id;
		}

		// Token: 0x06045DCE RID: 286158 RVA: 0x0124B8B0 File Offset: 0x01249AB0
		public int EnableAbsoluteNearClip(int priority, float distance)
		{
			CameraNearClipConfig cameraNearClipConfig = new CameraNearClipConfig(priority);
			cameraNearClipConfig.SetAbsoluteNearClip(distance);
			this.CameraNearClipConfigList.Push(cameraNearClipConfig);
			this.CameraNearClipConfigMap[cameraNearClipConfig.Id] = cameraNearClipConfig;
			this.UpdateCameraNearClip();
			return cameraNearClipConfig.Id;
		}

		// Token: 0x06045DCF RID: 286159 RVA: 0x0124B8F8 File Offset: 0x01249AF8
		public void DisableCameraNearClip(int id)
		{
			CameraNearClipConfig cameraNearClipConfig;
			if (this.CameraNearClipConfigMap.TryGetValue(id, out cameraNearClipConfig))
			{
				cameraNearClipConfig.MarkDelete = true;
				ICameraNearClipAction<CameraBaseNearClipConfig> cameraNearClipAction;
				if (this.CurrentNearClipActionMap.TryGetValue(cameraNearClipConfig, out cameraNearClipAction))
				{
					cameraNearClipAction.End();
					this.CurrentNearClipActionMap.Remove(cameraNearClipConfig);
				}
			}
			if (id == this.CurrentNearClipId)
			{
				this.ClearCurrent("因为禁用销毁，id: " + id.ToString());
			}
			this.UpdateCameraNearClip();
		}

		// Token: 0x06045DD0 RID: 286160 RVA: 0x0124B968 File Offset: 0x01249B68
		[NullableContext(2)]
		public CameraNearClipConfig GetCameraNearClipConfig()
		{
			while (!this.CameraNearClipConfigList.Empty)
			{
				CameraNearClipConfig top = this.CameraNearClipConfigList.Top;
				if (top == null)
				{
					return null;
				}
				if (!top.MarkDelete && top.IsValid())
				{
					return top;
				}
				this.CameraNearClipConfigList.Pop();
				this.CameraNearClipConfigMap.Remove(top.Id);
			}
			return null;
		}

		// Token: 0x06045DD1 RID: 286161 RVA: 0x0124B9C8 File Offset: 0x01249BC8
		public void ClearLevelEventAdjustPlayerCameraNearClip()
		{
			if (this.LevelEventAdjustPlayerCameraNearClipId <= 0)
			{
				return;
			}
			this.DisableCameraNearClip(this.LevelEventAdjustPlayerCameraNearClipId);
			this.LevelEventAdjustPlayerCameraNearClipId = 0;
		}

		// Token: 0x06045DD2 RID: 286162 RVA: 0x0124B9E8 File Offset: 0x01249BE8
		public void EnableLevelEventAdjustPlayerCameraNearClip(float? nearClipDistanceToTarget)
		{
			this.ClearLevelEventAdjustPlayerCameraNearClip();
			if (nearClipDistanceToTarget == null)
			{
				return;
			}
			float? num = nearClipDistanceToTarget;
			float num2 = 0f;
			if (num.GetValueOrDefault() <= num2 & num != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[CameraNearClip][Invalid Near Clip Distance";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("distance", nearClipDistanceToTarget);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.LevelEventAdjustPlayerCameraNearClipId = this.EnableRelativeNearClip(1000, nearClipDistanceToTarget.Value);
		}

		// Token: 0x06045DD3 RID: 286163 RVA: 0x0124BA69 File Offset: 0x01249C69
		public void ClearSequenceCameraPlayerComponentNearClip()
		{
			if (this.SequenceCameraPlayerComponentNearClipId <= 0)
			{
				return;
			}
			this.DisableCameraNearClip(this.SequenceCameraPlayerComponentNearClipId);
			this.SequenceCameraPlayerComponentNearClipId = 0;
		}

		// Token: 0x06045DD4 RID: 286164 RVA: 0x0124BA88 File Offset: 0x01249C88
		public void EnableSequenceCameraPlayerComponentNearClip(float clipDistance)
		{
			this.ClearSequenceCameraPlayerComponentNearClip();
			if (clipDistance <= 0f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[CameraNearClip][Invalid Sequence Near Clip Distance";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("distance", clipDistance);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.SequenceCameraPlayerComponentNearClipId = this.EnableAbsoluteNearClip(2000, clipDistance);
		}

		// Token: 0x06045DD5 RID: 286165 RVA: 0x0124BAE2 File Offset: 0x01249CE2
		public void ClearTsAnimNotifyStateNearClip()
		{
			if (this.TsAnimNotifyStateNearClipId <= 0)
			{
				return;
			}
			this.DisableCameraNearClip(this.TsAnimNotifyStateNearClipId);
			this.TsAnimNotifyStateNearClipId = 0;
		}

		// Token: 0x06045DD6 RID: 286166 RVA: 0x0124BB04 File Offset: 0x01249D04
		public void EnableTsAnimNotifyStateNearClip(float clipDistance)
		{
			this.ClearTsAnimNotifyStateNearClip();
			if (clipDistance <= 0f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[CameraNearClip][Invalid ANS Near Clip Distance";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("distance", clipDistance);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.TsAnimNotifyStateNearClipId = this.EnableAbsoluteNearClip(500, clipDistance);
		}

		// Token: 0x06045DD7 RID: 286167 RVA: 0x0124BB60 File Offset: 0x01249D60
		private void UpdateCameraNearClip()
		{
			CameraNearClipConfig cameraNearClipConfig = this.GetCameraNearClipConfig();
			if (cameraNearClipConfig == null)
			{
				this.ClearCurrent("没有有效配置");
				return;
			}
			if (this.CurrentNearClipId == cameraNearClipConfig.Id)
			{
				return;
			}
			if (this.CurrentNearClipAction != null)
			{
				this.CurrentNearClipAction.Pause();
			}
			this.ClearCurrent("将要更新新裁剪面，还原默认裁剪面");
			ICameraNearClipAction<CameraBaseNearClipConfig> cameraNearClipAction = null;
			ICameraNearClipAction<CameraBaseNearClipConfig> cameraNearClipAction2;
			if (this.CurrentNearClipActionMap.TryGetValue(cameraNearClipConfig, out cameraNearClipAction2))
			{
				cameraNearClipAction2.Resume();
				cameraNearClipAction = cameraNearClipAction2;
			}
			else
			{
				if (cameraNearClipConfig.Type == ECameraNearClipType.Relative)
				{
					CameraRelativeNearClipConfig config = (CameraRelativeNearClipConfig)cameraNearClipConfig.CameraBaseNearClip;
					cameraNearClipAction = CameraNearClipConstructorFactory.Create(cameraNearClipConfig.Type, cameraNearClipConfig.Id, config);
				}
				else if (cameraNearClipConfig.Type == ECameraNearClipType.Absolute)
				{
					CameraAbsoluteNearClipConfig config2 = (CameraAbsoluteNearClipConfig)cameraNearClipConfig.CameraBaseNearClip;
					cameraNearClipAction = CameraNearClipConstructorFactory.Create(cameraNearClipConfig.Type, cameraNearClipConfig.Id, config2);
				}
				if (cameraNearClipAction == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Camera;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "[CameraNearClip][请补充对应类型实现]";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", cameraNearClipConfig.Type);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.CurrentNearClipActionMap[cameraNearClipConfig] = cameraNearClipAction;
				cameraNearClipAction.Start();
			}
			this.CurrentNearClipId = cameraNearClipConfig.Id;
			this.CurrentNearClipAction = cameraNearClipAction;
		}

		// Token: 0x06045DD8 RID: 286168 RVA: 0x0124BC7F File Offset: 0x01249E7F
		protected override bool OnClear()
		{
			this.ClearAll("CameraNearClipController触发OnClear");
			return true;
		}

		// Token: 0x06045DD9 RID: 286169 RVA: 0x0124BC90 File Offset: 0x01249E90
		private void ClearCurrent(string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraNearClip][还原近裁剪面]";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CurrentNearClipId = 0;
			this.CurrentNearClipAction = null;
			UKuroCameraFunctionLibrary.DelaySetNearClipPlane(10f);
		}

		// Token: 0x06045DDA RID: 286170 RVA: 0x0124BCDC File Offset: 0x01249EDC
		public void ClearAll(string reason)
		{
			this.ClearCurrent(reason);
			foreach (KeyValuePair<CameraNearClipConfig, ICameraNearClipAction<CameraBaseNearClipConfig>> keyValuePair in this.CurrentNearClipActionMap)
			{
				keyValuePair.Value.End();
			}
			this.CurrentNearClipActionMap.Clear();
			this.CameraNearClipConfigMap.Clear();
			this.CameraNearClipConfigList.Clear();
		}

		// Token: 0x04027204 RID: 160260
		private int CurrentNearClipId;

		// Token: 0x04027205 RID: 160261
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ICameraNearClipAction<CameraBaseNearClipConfig> CurrentNearClipAction;

		// Token: 0x04027206 RID: 160262
		private readonly Dictionary<CameraNearClipConfig, ICameraNearClipAction<CameraBaseNearClipConfig>> CurrentNearClipActionMap = new Dictionary<CameraNearClipConfig, ICameraNearClipAction<CameraBaseNearClipConfig>>();

		// Token: 0x04027207 RID: 160263
		private readonly Dictionary<int, CameraNearClipConfig> CameraNearClipConfigMap = new Dictionary<int, CameraNearClipConfig>();

		// Token: 0x04027208 RID: 160264
		private readonly PriorityQueue<CameraNearClipConfig> CameraNearClipConfigList;

		// Token: 0x04027209 RID: 160265
		public int LevelEventAdjustPlayerCameraNearClipId;

		// Token: 0x0402720A RID: 160266
		public int SequenceCameraPlayerComponentNearClipId;

		// Token: 0x0402720B RID: 160267
		public int TsAnimNotifyStateNearClipId;
	}
}
