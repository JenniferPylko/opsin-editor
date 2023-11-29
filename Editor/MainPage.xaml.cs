namespace Editor;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"{count} dead crewmate";
		else
			CounterBtn.Text = $"{count} dead crewmates";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

