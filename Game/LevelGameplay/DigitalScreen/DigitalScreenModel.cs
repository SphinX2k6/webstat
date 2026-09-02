using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay.DigitalScreen
{
	// Token: 0x02006F20 RID: 28448
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class DigitalScreenModel : ModelBase<DigitalScreenModel>
	{
		// Token: 0x06044E5E RID: 282206 RVA: 0x011EEE30 File Offset: 0x011ED030
		public unsafe bool InitDigitalScreen(int index)
		{
			this.StartTimes = Array.Empty<float>();
			this.EndTimes = Array.Empty<float>();
			this.DelayTimes = Array.Empty<float>();
			this.DuringTimes = Array.Empty<float>();
			this.TextLength = Array.Empty<int>();
			this.Font = Array.Empty<int>();
			this.ContentPos = Array.Empty<int>();
			this.During = 0f;
			this.Text = "";
			DigitalScreen value = ConfigDigitalScreenById.GetConfig(index, true).Value;
			this.ExistTime = value.ExistTime;
			this.TextFactor = value.TextFactor;
			this.BackgroundPicture = value.BackgroundPicture;
			this.LogoIcon = value.LogoIconPath;
			this.ViewType = value.Prefab;
			Span<int> textIdBytes = value.GetTextIdBytes();
			this.Size = textIdBytes.Length;
			Span<int> span = textIdBytes;
			for (int i = 0; i < span.Length; i++)
			{
				DigitalScreenText? config = ConfigDigitalScreenTextById.GetConfig(*span[i], true);
				float[] array = this.StartTimes;
				int num = 0;
				float[] array2 = new float[1 + array.Length];
				ReadOnlySpan<float> readOnlySpan = new ReadOnlySpan<float>(array);
				readOnlySpan.CopyTo(new Span<float>(array2).Slice(num, readOnlySpan.Length));
				num += readOnlySpan.Length;
				array2[num] = config.Value.ShowStartFrame;
				this.StartTimes = array2;
				array2 = this.EndTimes;
				num = 0;
				array = new float[1 + array2.Length];
				readOnlySpan = new ReadOnlySpan<float>(array2);
				readOnlySpan.CopyTo(new Span<float>(array).Slice(num, readOnlySpan.Length));
				num += readOnlySpan.Length;
				array[num] = config.Value.ShowEndFrame;
				this.EndTimes = array;
				float num2 = config.Value.ShowEndFrame - config.Value.ShowStartFrame;
				this.During += ((num2 >= 0f) ? num2 : 1f);
				array = this.DuringTimes;
				num = 0;
				array2 = new float[1 + array.Length];
				readOnlySpan = new ReadOnlySpan<float>(array);
				readOnlySpan.CopyTo(new Span<float>(array2).Slice(num, readOnlySpan.Length));
				num += readOnlySpan.Length;
				array2[num] = ((num2 >= 0f) ? num2 : 1f);
				this.DuringTimes = array2;
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(config.Value.TextContentId, null);
				this.Text += localTextNew;
				int num3 = (localTextNew.Length == 0) ? 1 : localTextNew.Length;
				int[] array3 = this.TextLength;
				num = 0;
				int[] array4 = new int[1 + array3.Length];
				ReadOnlySpan<int> readOnlySpan2 = new ReadOnlySpan<int>(array3);
				readOnlySpan2.CopyTo(new Span<int>(array4).Slice(num, readOnlySpan2.Length));
				num += readOnlySpan2.Length;
				array4[num] = num3;
				this.TextLength = array4;
				int num4 = (config.Value.FontSize == 0) ? 12 : config.Value.FontSize;
				array4 = this.Font;
				num = 0;
				array3 = new int[1 + array4.Length];
				readOnlySpan2 = new ReadOnlySpan<int>(array4);
				readOnlySpan2.CopyTo(new Span<int>(array3).Slice(num, readOnlySpan2.Length));
				num += readOnlySpan2.Length;
				array3[num] = num4;
				this.Font = array3;
				array3 = this.ContentPos;
				num = 0;
				array4 = new int[1 + array3.Length];
				readOnlySpan2 = new ReadOnlySpan<int>(array3);
				readOnlySpan2.CopyTo(new Span<int>(array4).Slice(num, readOnlySpan2.Length));
				num += readOnlySpan2.Length;
				array4[num] = config.Value.Alignment;
				this.ContentPos = array4;
			}
			for (int j = 0; j < this.StartTimes.Length - 1; j++)
			{
				if (this.EndTimes[j] < this.StartTimes[j + 1])
				{
					float[] array2 = this.DelayTimes;
					int i = 0;
					float[] array = new float[1 + array2.Length];
					ReadOnlySpan<float> readOnlySpan = new ReadOnlySpan<float>(array2);
					readOnlySpan.CopyTo(new Span<float>(array).Slice(i, readOnlySpan.Length));
					i += readOnlySpan.Length;
					array[i] = this.StartTimes[j + 1] - this.EndTimes[j];
					this.DelayTimes = array;
				}
				else
				{
					float[] array = this.DelayTimes;
					int i = 0;
					float[] array2 = new float[1 + array.Length];
					ReadOnlySpan<float> readOnlySpan = new ReadOnlySpan<float>(array);
					readOnlySpan.CopyTo(new Span<float>(array2).Slice(i, readOnlySpan.Length));
					i += readOnlySpan.Length;
					array2[i] = 0f;
					this.DelayTimes = array2;
				}
			}
			return true;
		}

		// Token: 0x06044E5F RID: 282207 RVA: 0x011EF348 File Offset: 0x011ED548
		public DigitalScreen? GetDataConfig(int index)
		{
			return ConfigDigitalScreenById.GetConfig(index, true);
		}

		// Token: 0x04026686 RID: 157318
		public int ExistTime;

		// Token: 0x04026687 RID: 157319
		public string BackgroundPicture = "";

		// Token: 0x04026688 RID: 157320
		public string LogoIcon = "";

		// Token: 0x04026689 RID: 157321
		public float TextFactor;

		// Token: 0x0402668A RID: 157322
		public float[] StartTimes = Array.Empty<float>();

		// Token: 0x0402668B RID: 157323
		private float[] EndTimes = Array.Empty<float>();

		// Token: 0x0402668C RID: 157324
		public float[] DelayTimes = Array.Empty<float>();

		// Token: 0x0402668D RID: 157325
		public float[] DuringTimes = Array.Empty<float>();

		// Token: 0x0402668E RID: 157326
		public int[] TextLength = Array.Empty<int>();

		// Token: 0x0402668F RID: 157327
		public int[] Font = Array.Empty<int>();

		// Token: 0x04026690 RID: 157328
		public int[] ContentPos = Array.Empty<int>();

		// Token: 0x04026691 RID: 157329
		public float During;

		// Token: 0x04026692 RID: 157330
		[Nullable(2)]
		public string Text = "";

		// Token: 0x04026693 RID: 157331
		public int ViewType;

		// Token: 0x04026694 RID: 157332
		public int Size;
	}
}
