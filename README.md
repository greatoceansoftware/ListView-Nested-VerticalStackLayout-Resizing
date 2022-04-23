# ListView-Nested-VerticalStackLayout-Resizing
This project demonstrates that the VerticalStackLayout does not expand when bound items are unhidden when the layout is nested in a ListView.

Running the application shows two views of the same underlying hierachical data structure/source (Phase-> Goals-> Activities).

Steps:
1. Build and run the project as Windows Machine.
2. Click the Declutter switch (ON). The first activity (Activity 1) in the underlying data structure will be hidden.
3. Click the Declutter switch again (OFF). The VerticalStackLayout on the left will properly expand to reveal the hidden Activity 1. The ListView-nested VerticalStackLayout on the right does not expand (for each goal) to show all five Activities.

I'm not sure if this is a bug or intended behavior, but it would be nice if the VSL resized (expanded) to reveal all IsVisible=true children.
